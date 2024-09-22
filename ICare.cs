using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    interface ICare
    {
        int NumFertilizer { get; set; }
        int NumWater {  get; set; }
        void Feed();
        void ProvideWater();
    }
}
