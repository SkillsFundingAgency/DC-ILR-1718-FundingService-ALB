using System.Collections.Generic;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class root : Iroot
    {
        public rootEntity[] Entities => entitiesField;

        public string Rules => rulesField;

        public rootInteractiveitems InteractiveItems => interactiveitemsField;

        public rootRelationship[] Relationship => relationshipsField;

        public string RuleFolders => rulefoldersField;

        public sbyte SchemaVersion => schemaversionField;

        public bool SchemaVersionSpecified => schemaversionFieldSpecified;
       
        public sbyte? SchemaVersionNullable => schemaversionFieldSpecified ? (sbyte?)schemaversionField : null;

        public string ProductVersion => productversionField;

        public IEnumerable<IrootEntity> RootEntities => Entities;

        public IrootInteractiveitems RootInteractiveItems => InteractiveItems;

        public IEnumerable<IrootRelationship> RootRelationship => Relationship;

    }
}