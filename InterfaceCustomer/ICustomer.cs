using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace InterfaceCustomer
{
    public interface ICustomer
    {
        int Id { get; set; }
        string CustomerType { get; set; }
        string CustomerName { get; set; }
          string PhoneNumber { get; set; }
          decimal BillAmount { get; set; }
          DateTime BillDate { get; set; }
          string Address { get; set; }

        void Validate();


    }
    /* Below is Design Pattern:- strategy Pattern*/
    public interface IValidation<AnyType>
    {
        void Validate(AnyType obj);
    }

    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> Validatetions = null;
        /* in Constructor Validation object like LeadValidation passed Via Factory injectorConstructor*/

        public CustomerBase(IValidation<ICustomer> obj)
        {
            Validatetions = obj;
        }
        [Key]
        public int Id { get; set; }
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        public CustomerBase()
        {
            CustomerName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";
        }
        public virtual void Validate()
        {
            Validatetions.Validate(this);
        }
    }
}
