using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryCustomer;
using InterfaceCustomer;
using InterfaceDAL;
using FactoryDALLayer;
namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        CustomerBase Cust = null;
        public Form1()
        {
            InitializeComponent();
        }
        public void Loadcontrol()
        {
            Cust.CustomerName = txtCustomerName.Text;
            Cust.BillAmount = Convert.ToDecimal(txtbillamt.Text);
            Cust.BillDate = Convert.ToDateTime(txtBilldate.Text);
            Cust.PhoneNumber  = txtPhoneNo.Text;
            Cust.Address = txtaddress.Text;
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                Loadcontrol();
                Cust.Validate();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
           
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBilldate.Text = DateTime.Today.ToShortDateString();
            Loadgrid();
        }

        public void Loadgrid()
        {
            //IDAL<CustomerBase> Cust = FactoryDAL<IDAL<CustomerBase>>.Create("EFF");
            //List<CustomerBase> objCust = new List<CustomerBase>();
            //objCust = Cust.Search();
            //dgv.DataSource = objCust;

        }
        private void cmbCustomertype_SelectedIndexChanged(object sender, EventArgs e)
        {


            /*  We using polymorphism which is act different in different conditions  */
            Cust = Factory<CustomerBase>.Create(cmbCustomertype.Text);


            /*  we are using Here direct Concrit Class..this is not fully decouple
             How can we Make it decouple.. we need to give object creation to Other CL or Or other class */
            
            //if(cmbCustomertype.Text=="Lead")
            //{
            //    Cust = new Lead();
            //}
            //else
            //{
            //    Cust = new Customer();
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IUow uow = FactoryDAL<IUow>.Create("EfUOW");
            Loadcontrol();
            IRepository<CustomerBase> objCust = FactoryDAL<IRepository<CustomerBase>>.Create(cmbDal.SelectedItem.ToString());
            objCust.SetUnitWork(uow);
            objCust.Add(Cust);
            uow.Committ();

            //IRepository<CustomerBase> objCust = FactoryDAL<IRepository<CustomerBase>>.Create(cmbDal.SelectedItem.ToString());
            //objCust.Add(Cust);
            //objCust.save();
        }

        private void btnUOW_Click(object sender, EventArgs e)
        {
            IUow uow = FactoryDAL<IUow>.Create("EfUOW");
            try
            {
                CustomerBase cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "Cust1";

                // Unit of work
                IRepository<CustomerBase> dal = FactoryDAL<IRepository<CustomerBase>>
                                     .Create(cmbDal.Text); // Unit
                dal.SetUnitWork(uow);
                dal.Add(cust1); // In memory


                cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "Cust2";
                cust1.Address = "dzxcczx";
                IRepository<CustomerBase> dal1 = FactoryDAL<IRepository<CustomerBase>>
                                     .Create(cmbDal.Text); // Unit
                dal1.SetUnitWork(uow);
                dal1.Add(cust1); // In memory

                uow.Committ();
            }
            catch (Exception ex)
            {
                uow.RollBack();
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
