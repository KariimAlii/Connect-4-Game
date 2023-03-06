using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Game
{
    [Serializable]
    internal class SerializedClass
    {
        public string lastPlayed;
        internal void serialize(string filename)
        {
            using (FileStream stream = new FileStream(@"E:\lastPlayed.txt", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, this);


            }


        }
        internal static SerializedClass deserialize(string filename)
        {
            using (FileStream stream = new FileStream(@"E:\ExampleNew2.txt", FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (SerializedClass)binaryFormatter.Deserialize(stream);

            }

        }
    }
}
