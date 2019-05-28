using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models
{
    public class Farm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RegisteredName { get; set; }

        public double Acres { get; set; }

        [NotMapped]
        public double Price { get; set; }

        public ApplicationUser User { get; set; }
    }
}
