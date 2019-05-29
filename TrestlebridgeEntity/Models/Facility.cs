using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models
{
    public class Facility
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FacilityTypeId { get; set; }

        [Required]
        public int FarmId { get; set; }

        public FacilityType Type { get; set; }

        public Farm Farm { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
