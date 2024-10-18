using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal interface ICloneable<T>
    {
        //Return a deep copy of the object T
        T DeepCopy();
    }
}
