using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    public class ChildClass : BaseClass, IParentClass  //인터페이스는 구현이라고 한다.
    {
        public ChildClass()
        {

        }

        public double GiveAccount()
        {
            throw new NotImplementedException();
        }
    }
}
