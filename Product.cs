using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public abstract class Product
    {
        public int Cost { get; set; }
        public int Value { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public int FertilizerCost { get; set; }
        public int WaterCost { get; set; }
        public int NumFertilizer { get; set; }
        public int NumWater { get; set; }
        public int TotalCost
        {
            get { return FertilizerCost*NumFertilizer + WaterCost*NumWater; }
        }

        public abstract void Seed();
        public abstract void Harvest();
    }
}
