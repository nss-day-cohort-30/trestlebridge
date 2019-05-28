using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models
{
    public class FacilityType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
