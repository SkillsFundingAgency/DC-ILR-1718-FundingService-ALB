using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model
{
    public partial class LARSVersion
    {
        public int MajorNumber { get; set; }
        public int MinorNumber { get; set; }
        public int MaintenanceNumber { get; set; }
        public string MainDataSchemaName { get; set; }
        public string RefDataSchemaName { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}

