using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    public interface IListOfObjects<T>
    {
        //Add a new object to the list
        void Add(T obj);
        //remove an item from teh list at index
        void RemoveAtIndex(int index);
        //DeepCopy of a list
        List<T> ListDeepCopy();
    }
}
