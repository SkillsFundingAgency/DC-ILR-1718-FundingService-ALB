﻿using System.Collections.Generic;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class rootEntity : IrootEntity
    {
        public rootEntityAttribute[] Attribute => attributeField;

        public string @Ref => refField;

        public string Id=> idField;

        public string Name => nameField;

        public string ContinmentRelationshipId => containmentrelationshipidField;

        public string ContainmentParentId => containmentparentidField;

        public string PublicId => publicidField;

        public IEnumerable<IrootEntityAttribute> EntityAttributes => Attribute;
    }
}
