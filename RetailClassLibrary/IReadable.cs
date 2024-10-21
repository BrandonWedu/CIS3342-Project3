using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal interface IReadable<T>
    {
        T GetById(int id);

    }
}
