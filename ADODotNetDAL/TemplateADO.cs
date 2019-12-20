using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CommanDAL;
using InterfaceCustomer;
using System.Data.Common;
using FactoryCustomer;
namespace ADODotNetDAL
{
    public abstract class TemplateADO<AnyType> : AbtractDAL<AnyType>
    {

        /* Design Pattern:- Template Pattern*/
        /* this pattern happened when Some steps are in sequence */

        private SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        protected string Connectionstring = null;
        public TemplateADO(string _ConnectionString) : base(_ConnectionString)
        {
            Connectionstring = _ConnectionString;
        }
        private void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }
        private void Close()
        {
            objConn.Close();
        }

        protected abstract void ExecuteCommand(AnyType obj);
        protected abstract List<AnyType> ExecuteCommand();
       
        public void Execute(AnyType obj)
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }

        public List<AnyType> Execute()
        {
            List<AnyType> Cust = new List<AnyType>();
            Open();
            Cust= ExecuteCommand();
            Close();
            return Cust;
        }

        public override void save()
        {
             foreach(var o in AnyTypes)
            {
                Execute(o);
            }
        }

        public override List<AnyType> Search()
        {
            return Execute();
        }
    }

    public class CustomerDAL  : TemplateADO<ICustomer>
    {
        
        public CustomerDAL(string _Connectionstring) :base(_Connectionstring)
        {
            
        }

        protected override List<ICustomer> ExecuteCommand()
        {
            SqlDataReader dr = null;
            objCommand.CommandText = "select * from tblCustomer";
            dr = objCommand.ExecuteReader();
            List<ICustomer> cust = new List<ICustomer>();
            while (dr.Read())
            {
                ICustomer cs = Factory<ICustomer>.Create("Customer");
                cs.CustomerName = dr["CustomerName"].ToString() ;
                cs.Address = dr["Address"].ToString();
                cs.BillAmount = Convert.ToInt32(dr["BillAmount"]);
                cs.BillDate = Convert.ToDateTime(dr["BillDate"]);
                cs.PhoneNumber = dr["PhoneNumber"].ToString();
                cust.Add(cs);
            }

            return cust;

        }
        protected override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "Insert into tblCustomer(CustomerName,BillAmount,BillDate,PhoneNumber,address)Values('" +  obj.CustomerName + "'," + obj.BillAmount +",'" + obj.BillDate + "'," + obj.PhoneNumber + ",'" + obj.Address +"' )";
            objCommand.ExecuteNonQuery();
        }

        
    }
}
