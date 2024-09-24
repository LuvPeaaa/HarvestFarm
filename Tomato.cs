using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Tomato : Product, ICare
    {
        public int NumFertilizer { get; set; }
        public int NumWater { get; set; }

        public Tomato(int cost, int value, int duration, int fertilizerCost, int waterCost, int numfertilizer, int numwater)
        {
            Cost = cost;
            Value = value;
            Duration = duration;
            FertilizerCost = fertilizerCost;
            WaterCost = waterCost;
            NumFertilizer = numfertilizer;
            NumWater = numwater;
        }
         bool NumFer()
        {
            if (NumFertilizer > 1)
            {
                NumFertilizer--;
                return true;

            }
            else
            {

                return false;
            }
        }
         bool NumWat()
        {
            if (NumWater > 1)
            {
                NumWater--;
                return true;
            }
            else
            {

                return false;

            }

        }
        public void Feed()
        {
            do
            {
                Console.WriteLine("Fertilizing 1 time");
            } while (NumFer());
        }

        public void ProvideWater()
        {

            do
            {
                Console.WriteLine("Watering 1 time");
            } while (NumWat());
        }
        public override void Seed()
        {
            Console.WriteLine("Seeding Tomato.");
            Start = DateTime.Now;
        }

        public override void Harvest()
        {
            while (true)
            {
                TimeSpan timeSinceSeed = DateTime.Now - Start;

                if (timeSinceSeed.TotalSeconds >= Duration)
                {
                    Console.WriteLine("Harvesting " + GetType().Name);
                    break;
                }
                else
                {
                    Console.WriteLine("Need more time to harvest.");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        
    }
}
