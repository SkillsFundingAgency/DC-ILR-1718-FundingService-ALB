using ESFA.DC.OPA.XSRC.Model.Input.Interface;
using ESFA.DC.OPA.XSRC.Model.Input.Models;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ESFA.DC.OPA.XSRC.Service
{
    public class Serializer
    {
        private Stream _stream;

        root model;

        public Serializer(Stream stream)
        {
            _stream = stream;
        }

        public root Deserialize()
        {
            using (var reader = XmlReader.Create(_stream))
            {
                var serializer = new XmlSerializer(typeof(root));
                model = serializer.Deserialize(reader) as root;
            }

            _stream.Close();

            return model;
        }
    }
}
