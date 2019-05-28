using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models
{
    public class AnimalType
    {
        [Key]
        public int Id { get; set; }

        public string Species { get; set; }


        public virtual ICollection<Animal> Animals { get; set; }
    }
}
