using ESFA.DC.OPA.XSRC.Model.Input.Models;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Setting internals visiible for unit test purposes
[assembly: InternalsVisibleTo("ESFA.DC.OPA.XSRC.Service.Tests")]

namespace ESFA.DC.OPA.XSRC.Service
{
    public class XsrcEntityBuilder
    {
        private readonly root _rootEntities;

        public XsrcEntityBuilder(root rootEntities)
        {
            _rootEntities = rootEntities;
        }

        public XsrcGlobal GlobalEntity()
        {
            return new XsrcGlobal
            {
                GlobalEntity =
              _rootEntities.entities.Where(r => r.@ref == "global")
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
                    Children = GetChildren(g.@ref)
                })
            };
        }

        internal protected IEnumerable<XsrcEntity> GetChildren(string parentName)
        {
            return
            _rootEntities.entities.Where(r => r.containmentparentid == parentName)
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
                   Children = GetChildren(c.id)
               });
        }
    }
}
