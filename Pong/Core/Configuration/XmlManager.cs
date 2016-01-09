using System.IO;
using System.Xml.Serialization;

namespace Pong.Core.Configuration
{
    public static class XmlManager<T>
    {
        public static void Save(string path, T obj)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, obj);
            }
        }
        public static T Load(string path)
        {
            T retVal;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var deserializer = new XmlSerializer(typeof(T));
                retVal = (T)deserializer.Deserialize(fs);
            }
            return retVal;
        }
    }
}