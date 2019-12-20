using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;
namespace MiddleLayer
{



  

    public class Customer : CustomerBase
    {
        public Customer()
        {
            CustomerType = "Customer";
        }
        public Customer(IValidation<ICustomer> obj) : base(obj)
        {
            CustomerType = "Customer";
        }
    }
    public class Lead : CustomerBase
    {
        public Lead()
        {
            CustomerType = "Lead";
        }
        public Lead(IValidation<ICustomer> obj) : base(obj)
        {
            CustomerType = "Lead";
        }
    }



    /*Below Code is duplication of Fields
    Solution - Create base class and Inherit in this class */

    //public class Customer
    //{
    //    public string CustomerName { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public decimal BillAmount { get; set; }
    //    public DateTime BillDate { get; set; }
    //    public string Address { get; set; }
    //}

    //public class Lead
    //{
    //    public string CustomerName { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public decimal BillAmount { get; set; }
    //    public DateTime BillDate { get; set; }
    //    public string Address { get; set; }
    //}
}
