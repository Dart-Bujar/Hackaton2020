using System;
using System.Collections.Generic;

#nullable disable

namespace CEEHACK_ASPServer.Models
{
    public partial class GenderType
    {
        public GenderType()
        {
            Patients = new HashSet<Patient>();
        }

        public int GenderId { get; set; }
        public string GenderDescription { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
