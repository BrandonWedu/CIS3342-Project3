using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal static class Serializer
    {
        public static byte[] SerializeData<T>(T data)
        {
            byte[] serializedData;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
                serializedData = stream.ToArray();
            }
            return serializedData;
        }

        public static T DeserializeData<T>(byte[] byteArray)
        {
            T deserializedObject;
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                deserializedObject = (T)formatter.Deserialize(stream);
            }
            return deserializedObject;
        }
    }
}
