using ESFA.DC.OPA.XSRC.Model.Input.Models;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models;
using ESFA.DC.OPA.XSRC.Service.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

// Setting internals visiible for unit test purposes
[assembly: InternalsVisibleTo("ESFA.DC.OPA.XSRC.Service.Tests")]

namespace ESFA.DC.OPA.XSRC.Service.Implementation
{
    public class XsrcEntityBuilder : IXsrcEntityBuilder
    {
        private string _xsrcInput;

        root model;

        public XsrcEntityBuilder(string xsrcInput)
        {
            _xsrcInput = xsrcInput;
        }

        public XsrcGlobal BuildXsrc()
        {
            var rootEntities = Deserialize();

            return GlobalEntity(rootEntities);
        }

        internal protected root Deserialize()
        {
            Stream stream = new FileStream(_xsrcInput, FileMode.Open);

            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(root));
                model = serializer.Deserialize(reader) as root;
            }

            stream.Close();

            return model;
        }

        internal protected XsrcGlobal GlobalEntity(root rootEntities)
        {
            return new XsrcGlobal
            {
                GlobalEntity =
                rootEntities.entities.Where(r => r.@ref == "global")
                .Select(g => new XsrcEntity
                {
                    PublicName = g.@ref,
                    Name = g.@ref,
                    Attributes = g.attribute.Select(ga =>
                    new XsrcAttribute
                    {
                        PublicName = ga.publicname,
                        Type = ga.type,
                        Properties = ga.props.Select(gp => new XsrcAttributeProperty
                        {
                            Name = gp.name,
                            Value = gp.Value
                        })
                    }),
                    Children = GetChildren(g.@ref, rootEntities)
                })
            };
        }

        internal protected IEnumerable<XsrcEntity> GetChildren(string parentName, root rootEntities)
        {
            return
               rootEntities.entities.Where(r => r.containmentparentid == parentName)
               .Select(c => new XsrcEntity
               {
                   PublicName = c.publicid,
                   Name = c.id,
                   Parent = parentName,
                   Attributes = c.attribute.Select(ca =>
                   new XsrcAttribute
                   {
                       PublicName = ca.publicname,
                       Type = ca.type,
                       Properties = ca.props.Select(cp => new XsrcAttributeProperty
                       {
                           Name = cp.name,
                           Value = cp.Value
                       })
                   }),
                   Children = GetChildren(c.id, rootEntities)
               });
        }
    }
}
