using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;
namespace MiddleLayer
{



    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> Validatetions = null;
        /* in Constructor Validation object like LeadValidation passed Via Factory injectorConstructor*/

        public CustomerBase(IValidation<ICustomer> obj)
        {
            Validatetions = obj;
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        public virtual void Validate()
        {
            Validatetions.Validate(this);
        }
    }

    public class Customer : CustomerBase
    {
        public Customer(IValidation<ICustomer> obj) : base(obj)
        {

        }
    }
    public class Lead : CustomerBase
    {

        public Lead(IValidation<ICustomer> obj) : base(obj)
        {

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
