using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDAL;
using System.Data.Entity;
using InterfaceCustomer;

namespace EFDAL
{
    public class EFAbtract<AnyType> : DbContext, IDAL<AnyType> where AnyType : class
    {
        public EFAbtract() : base("name=Conn")
        {

        }
        public void Add(AnyType obj)
        {
            Set<AnyType>().Add(obj);
        }

        public void save()
        {
            SaveChanges();
        }

        public List<AnyType> Search()
        {
            return Set<AnyType>().AsQueryable<AnyType>().ToList<AnyType>();
        }

        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }

    public class EFCustomerDAL : EFAbtract<CustomerBase>
    {
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBase>()
                        .ToTable("tblCustomer");
        }

    }

}

  
