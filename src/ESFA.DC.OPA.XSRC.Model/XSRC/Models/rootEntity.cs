using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class rootEntity
    {

        private rootEntityAttribute[] attributeField;

        private string refField;

        private string idField;

        private string nameField;

        private string containmentrelationshipidField;

        private string containmentparentidField;

        private string publicidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public rootEntityAttribute[] attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("containment-relationship-id")]
        public string containmentrelationshipid
        {
            get
            {
                return this.containmentrelationshipidField;
            }
            set
            {
                this.containmentrelationshipidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("containment-parent-id")]
        public string containmentparentid
        {
            get
            {
                return this.containmentparentidField;
            }
            set
            {
                this.containmentparentidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("public-id")]
        public string publicid
        {
            get
            {
                return this.publicidField;
            }
            set
            {
                this.publicidField = value;
            }
        }
    }
}
