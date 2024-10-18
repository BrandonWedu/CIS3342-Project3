using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal class HomeImages : IListOfObjects<HomeImage>, ICloneable<HomeImages>
    {
        //Fields
        List<HomeImage> images;

        //Constructor with no params
        public HomeImages()
        {
            images = new List<HomeImage>();
        }
        //Constructor with 
        public HomeImages(List<HomeImage> images)
        {
            foreach (var image in images)
            {
                this.images.Add(image.DeepCopy());
            }
        }
        //Get Set
        public List<HomeImage> Images
        {
            get { return ListDeepCopy(images); }
            set { images = ListDeepCopy(value);  }
        }

        //Interface Methods
        public List<HomeImage> ListDeepCopy(List<HomeImage> list)
        {
            List<HomeImage> tempList = new List<HomeImage>();
            foreach (var image in list)
            {
                tempList.Add(image.DeepCopy());
            }
            return tempList;
        }
        public void Add(HomeImage obj)
        {
            images.Add(obj.DeepCopy());
        }
        public HomeImages DeepCopy()
        {
            return new HomeImages(ListDeepCopy(images)); 
        }
        public void RemoveAtIndex(int index)
        {
            images.RemoveAt(index);
        }
    }
}
