using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models.ViewModels
{
    public class GroupedFarm
    {
        public int FarmId { get; set; }

        [Display(Name="Name")]
        public string RegisteredName { get; set; }

        public double Acres { get; set; }

        [Display(Name="Number of Facilities")]
        public int Count { get; set; }

    }
}
