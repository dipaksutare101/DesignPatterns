using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;
namespace ValidationAlgorithem
{
    public class ValidationCustomer : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Please Enter Customer Name");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Please Enter PhoneNumber");
            }
            if (obj.BillAmount == 0)
            {
                throw new Exception("Please Enter BillAmount");
            }
            if (obj.BillDate >= DateTime.Now)
            {
                throw new Exception("Please Enter BillDate");
            }
            if (obj.Address.Length == 0)
            {
                throw new Exception("Please Enter Address");
            }
        }

      
    }
    public class ValidationLead : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Please Enter Customer Name");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Please Enter PhoneNumber");
            }
        }
    }
}
