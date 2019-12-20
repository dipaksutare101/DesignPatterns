using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDAL;
using System.Data.Entity;
using InterfaceCustomer;

namespace EfDal
{
    // Design pattern :- Adpater pattern ( class Adapter pattern)
    public class EfDalAbstract<AnyType> : DbContext, IDAL<AnyType>
        where AnyType : class
    {
        public EfDalAbstract()
            : base("name=Conn")
        {

        }
        public void Add(AnyType obj)
        {
            Set<AnyType>().Add(obj); // in memory committ
        }
        
        public void save()
        {
            SaveChanges(); //physical committ
        }
        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public List<AnyType> Search()
        {
            return Set<AnyType>().
                     AsQueryable<AnyType>().
                         ToList<AnyType>();       
        }

        
    }

    public class EfCustomerDal :
                EfDalAbstract<CustomerBase>
    {
        // mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mapping code
            modelBuilder.Entity<CustomerBase>()
                        .ToTable("tblCustomer");
           

        }
    }
}
