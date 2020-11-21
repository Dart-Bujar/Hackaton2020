using System;
using System.Collections.Generic;

#nullable disable

namespace CEEHACK_ASPServer.Models
{
    public partial class Patient
    {
        public Patient()
        {
            PatientCases = new HashSet<PatientCase>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float IsWeight { get; set; }
        public float IsHeight { get; set; }
        public int Gender { get; set; }

        public virtual GenderType GenderNavigation { get; set; }
        public virtual ICollection<PatientCase> PatientCases { get; set; }
    }
}
