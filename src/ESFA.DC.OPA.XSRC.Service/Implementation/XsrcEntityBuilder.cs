using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;
using ESFA.DC.OPA.XSRC.Model.XSRC.Models;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models;
using ESFA.DC.OPA.XSRC.Service.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Xml;

// Setting internals visiible for unit test purposes
[assembly: InternalsVisibleTo("ESFA.DC.OPA.XSRC.Service.Tests")]

namespace ESFA.DC.OPA.XSRC.Service.Implementation
{
    public class XsrcEntityBuilder : IXsrcEntityBuilder
    {
        private string _xsrcInput;

        IRoot model;

        public XsrcEntityBuilder(string xsrcInput)
        {
            _xsrcInput = xsrcInput;
        }

        public XsrcGlobal BuildXsrc()
        {
            var rootEntities = Deserialize();
                       
            return GlobalEntity(rootEntities);
        }

        internal protected IRoot Deserialize()
        {
            Stream stream = new FileStream(_xsrcInput, FileMode.Open);

            ISerializationService serializationService = new XmlSerializationService();

            IRoot rootEntities = serializationService.Deserialize<Root>(stream);

            stream.Close();

            return rootEntities;
        }

        internal protected XsrcGlobal GlobalEntity(IRoot rootEntities)
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

        internal protected IEnumerable<XsrcEntity> GetChildren(string parentName, IRoot rootEntities)
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
