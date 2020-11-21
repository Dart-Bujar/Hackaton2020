using System;
using System.Collections.Generic;

#nullable disable

namespace CEEHACK_ASPServer.Models
{
    public partial class Record
    {
        public int? CaseId { get; set; }
        public int RecordId { get; set; }
        public float? PredictedValue { get; set; }
        public float? CorrectedValue { get; set; }
        public DateTime? RecordDate { get; set; }
        public int? DrugType { get; set; }

        public virtual PatientCase Case { get; set; }
        public virtual DrugType DrugTypeNavigation { get; set; }
    }
}
