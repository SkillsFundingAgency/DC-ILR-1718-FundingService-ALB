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
    public class rootRelationship
    {

        private string sourceField;

        private string targetField;

        private string textField;

        private string relationshipidField;

        private string reversetextField;

        private string reverserelationshipidField;

        private string typeField;

        private string iscomputedField;

        private string iscontainmentField;

        private string publicidField;

        private string reversepublicidField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("relationship-id")]
        public string relationshipid
        {
            get
            {
                return this.relationshipidField;
            }
            set
            {
                this.relationshipidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("reverse-text")]
        public string reversetext
        {
            get
            {
                return this.reversetextField;
            }
            set
            {
                this.reversetextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("reverse-relationship-id")]
        public string reverserelationshipid
        {
            get
            {
                return this.reverserelationshipidField;
            }
            set
            {
                this.reverserelationshipidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("is-computed")]
        public string iscomputed
        {
            get
            {
                return this.iscomputedField;
            }
            set
            {
                this.iscomputedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("is-containment")]
        public string iscontainment
        {
            get
            {
                return this.iscontainmentField;
            }
            set
            {
                this.iscontainmentField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("reverse-public-id")]
        public string reversepublicid
        {
            get
            {
                return this.reversepublicidField;
            }
            set
            {
                this.reversepublicidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
