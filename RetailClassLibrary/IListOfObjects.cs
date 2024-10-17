using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal interface IListOfObjects
    {
        void Add(object obj);
        void RemoveAtIndex(int index);
    }
}
