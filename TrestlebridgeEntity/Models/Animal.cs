using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalTypeId { get; set; }

        [Required]
        public int FacilityId { get; set; }

        public AnimalType AnimalType { get; set; }

        public Facility Facility { get; set; }
    }
}
