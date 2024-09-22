using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Player
    {
        public string UserName { get; set; }
        public int Reward { get; set; }

        public Player(string userName, int reward)
        {
            UserName = userName;
            Reward = reward;
        }

        public void AddReward (int points)
        {
            Reward += points;
            Console.WriteLine($"{UserName} got {points} points. Total Points: {Reward}");
        }

        public void DeductReward(int points)
        {
            if (Reward < points)
            {
                throw new InvalidOperationException("Not enough points to buy!");          
            }
            Reward -= points;
            Console.WriteLine($"{UserName} used {points} points. Total Points: {Reward}");
        }
    }
}
