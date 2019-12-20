using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public interface IDAL<AnyType>
    {
        void Add(AnyType obj);  //In Memory additions
        void Update(AnyType obj);
        List<AnyType> Search();
        void save();
    }
}
