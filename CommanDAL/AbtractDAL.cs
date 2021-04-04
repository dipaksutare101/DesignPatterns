using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDAL;

namespace CommanDAL
{
    public class AbtractDAL<AnyType> : IRepository<AnyType>
    {
        protected List<AnyType> AnyTypes = new List<AnyType>();
        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

      

        public virtual void SetUnitWork(IUow uow)
        {
            throw new NotImplementedException();
        }

        public virtual void save()
        {
            throw new NotImplementedException();
        }
    }
}
