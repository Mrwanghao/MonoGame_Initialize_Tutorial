using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace Utils
{
    public class XMLSerialize
    {
        public void Serialize(object data)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(data.GetType());
                xz.Serialize(sw, data);
            }

            //MyXMLData.MyLevel testData = new MyXMLData.MyLevel();
            //testData.LevelName = "MyLevel";
            //testData.MaxEnemies = 99999;

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;

            //using (XmlWriter writer = XmlWriter.Create("test.xml", settings))
            //{
            //    Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate.IntermediateSerializer.Serialize(writer, testData, null);
            //}
        }

    }
}
