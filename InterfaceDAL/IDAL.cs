using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public interface IRepository<AnyType>
    {
        void SetUnitWork(IUow uow);
        void Add(AnyType obj);  //In Memory additions
        void Update(AnyType obj);
        List<AnyType> Search();
        void save();
    }

    public interface IUow
    {
        void Committ();
        void RollBack();
    }
}
