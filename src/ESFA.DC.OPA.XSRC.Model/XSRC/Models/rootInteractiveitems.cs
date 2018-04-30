using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class RootInteractiveitems : IRootInteractiveitems
    {
        public string Folders => foldersField;

        public string Screens => screensField;

        public string Documents => documentsField;
   }
}
