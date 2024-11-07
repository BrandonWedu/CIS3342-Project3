using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    public abstract class ListOfObjects<T> : IListOfObjects<T> where T : ICloneable<T>
    {
        //Field
        protected List<T> list = new List<T>();

        //Get Set
        public List<T> List
        {
            get { return ListDeepCopy(); }
            set
            {
                list.Clear();
                foreach (T item in value)
                { 
                    Add(item);
                }
            }
        }

        //Implement Interface
        public void Add(T obj)
        {
            list.Add(obj.DeepCopy());
        }
        public void RemoveAtIndex(int index)
        {
            if (index > -1 && index < list.Count)
            {
                list.RemoveAt(index);
            }
        }
        public List<T> ListDeepCopy()
        {
            List<T> temp = new List<T>();   
            foreach(T obj in list)
            {
                temp.Add(obj.DeepCopy());
            }
            return temp;
        }
    }
}
