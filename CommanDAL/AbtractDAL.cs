using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDAL;

namespace CommanDAL
{
    public class AbtractDAL<AnyType> : IDAL<AnyType>
    {
        protected List<AnyType> AnyTypes = new List<AnyType>();
        protected  string ConnectionString="";
        public AbtractDAL(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        /* make All method to Virtual so, Child classes can Override*/
        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void save()
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }
}
