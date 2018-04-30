using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;
using ESFA.DC.OPA.XSRC.Model.XSRC.Models;
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

        Iroot model;

        public XsrcEntityBuilder(string xsrcInput)
        {
            _xsrcInput = xsrcInput;
        }

        public XsrcGlobal BuildXsrc()
        {
            var rootEntities = Deserialize();

            return GlobalEntity(rootEntities);
        }

        internal protected Iroot Deserialize()
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

        internal protected XsrcGlobal GlobalEntity(Iroot rootEntities)
        {
            return new XsrcGlobal
            {
                GlobalEntity =
                rootEntities.RootEntities.Where(r => r.@Ref == "global")
                .Select(g => new XsrcEntity
                {
                    PublicName = g.@Ref,
                    Name = g.@Ref,
                    Attributes = g.EntityAttributes.Select(ga =>
                    new XsrcAttribute
                    {
                        PublicName = ga.PublicName,
                        Type = ga.Type,
                        //Properties = ga.props.Select(gp => new XsrcAttributeProperty
                        //{
                        //    Name = gp.name,
                        //    Value = gp.Value
                        //})
                    }),
                    Children = GetChildren(g.@Ref, rootEntities)
                }).Single()
            };
        }

        internal protected IEnumerable<XsrcEntity> GetChildren(string parentName, Iroot rootEntities)
        {
            return
               rootEntities.RootEntities.Where(r => r.ContainmentParentId == parentName)
               .Select(c => new XsrcEntity
               {
                   PublicName = c.PublicId,
                   Name = c.Id,
                   Parent = parentName,
                   Attributes = c.EntityAttributes.Select(ca =>
                   new XsrcAttribute
                   {
                       PublicName = ca.PublicName,
                       Type = ca.Type,
                       //Properties = ca.props.Select(cp => new XsrcAttributeProperty
                       //{
                       //    Name = cp.name,
                       //    Value = cp.Value
                       //})
                   }),
                   Children = GetChildren(c.Id, rootEntities)
               });
        }
    }
}
