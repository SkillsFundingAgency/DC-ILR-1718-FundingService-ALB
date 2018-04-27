using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class rootEntityAttribute
    {

        private rootEntityAttributeText textField;

        private rootEntityAttributeProp[] propsField;

        private string nameField;

        private string typeField;

        private string publicnameField;

        /// <remarks/>
        public rootEntityAttributeText text
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
        [System.Xml.Serialization.XmlArrayItemAttribute("prop", IsNullable = false)]
        public rootEntityAttributeProp[] props
        {
            get
            {
                return this.propsField;
            }
            set
            {
                this.propsField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute("public-name")]
        public string publicname
        {
            get
            {
                return this.publicnameField;
            }
            set
            {
                this.publicnameField = value;
            }
        }
    }
}
