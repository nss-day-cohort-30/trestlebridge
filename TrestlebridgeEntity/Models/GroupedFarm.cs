using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrestlebridgeEntity.Models
{
    public class GroupedFarm
    {
        public int FarmId { get; set; }
        public string RegisteredName { get; set; }
        public double Acres { get; set; }
        public int Count { get; set; }

        //FarmId = farmGroup.Key.FarmId,
        //                RegisteredName = farmGroup.Key.RegisteredName,
        //                Acres = farmGroup.Key.Acres,
        //                Count = farmGroup.Count()
    }
}
