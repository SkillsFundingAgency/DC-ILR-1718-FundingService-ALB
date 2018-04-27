namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class root
    {

        private rootEntity[] entitiesField;

        private string rulesField;

        private rootInteractiveitems interactiveitemsField;

        private rootRelationship[] relationshipsField;

        private string rulefoldersField;

        private sbyte schemaversionField;

        private bool schemaversionFieldSpecified;

        private string productversionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("entity", IsNullable = false)]
        public rootEntity[] entities
        {
            get
            {
                return this.entitiesField;
            }
            set
            {
                this.entitiesField = value;
            }
        }

        /// <remarks/>
        public string rules
        {
            get
            {
                return this.rulesField;
            }
            set
            {
                this.rulesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("interactive-items")]
        public rootInteractiveitems interactiveitems
        {
            get
            {
                return this.interactiveitemsField;
            }
            set
            {
                this.interactiveitemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("relationship", IsNullable = false)]
        public rootRelationship[] relationships
        {
            get
            {
                return this.relationshipsField;
            }
            set
            {
                this.relationshipsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("rule-folders")]
        public string rulefolders
        {
            get
            {
                return this.rulefoldersField;
            }
            set
            {
                this.rulefoldersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("schema-version")]
        public sbyte schemaversion
        {
            get
            {
                return this.schemaversionField;
            }
            set
            {
                this.schemaversionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool schemaversionSpecified
        {
            get
            {
                return this.schemaversionFieldSpecified;
            }
            set
            {
                this.schemaversionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("product-version")]
        public string productversion
        {
            get
            {
                return this.productversionField;
            }
            set
            {
                this.productversionField = value;
            }
        }
    }
}