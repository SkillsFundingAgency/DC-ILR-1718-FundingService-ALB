using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class rootInteractiveitems : IrootInteractiveitems
    {
        public string Folders => foldersField;

        public string Screens => screensField;

        public string Documents => documentsField;
   }
}
