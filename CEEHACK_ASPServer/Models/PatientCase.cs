using System;
using System.Collections.Generic;

#nullable disable

namespace CEEHACK_ASPServer.Models
{
    public partial class PatientCase
    {
        public PatientCase()
        {
            Records = new HashSet<Record>();
        }

        public int CaseId { get; set; }
        public int? PatientId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
