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
    public class rootInteractiveitems
    {

        private string foldersField;

        private string screensField;

        private string documentsField;

        /// <remarks/>
        public string folders
        {
            get
            {
                return this.foldersField;
            }
            set
            {
                this.foldersField = value;
            }
        }

        /// <remarks/>
        public string screens
        {
            get
            {
                return this.screensField;
            }
            set
            {
                this.screensField = value;
            }
        }

        /// <remarks/>
        public string documents
        {
            get
            {
                return this.documentsField;
            }
            set
            {
                this.documentsField = value;
            }
        }
    }
}
