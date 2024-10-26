using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RetailClassLibrary
{
    internal static class ReadRooms
    {
        internal static HomeRooms GetByHomeID(int homeID)
        {
            return new HomeRooms();
        }
    }
}
