using System;
using System.Collections.Generic;

#nullable disable

namespace CEEHACK_ASPServer.Models
{
    public partial class DrugType
    {
        public DrugType()
        {
            Records = new HashSet<Record>();
        }

        public int DrugTypeId { get; set; }
        public string DrugTypeDescription { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
