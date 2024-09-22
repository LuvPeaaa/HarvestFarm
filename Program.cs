using HarvestFarm;
using System;

class Program
{
    public static void Main()
    {
        Player player = new Player("TBB", 100);

        List<Product> products = new List<Product>();

        Wheat wheat = new Wheat(30, 50, 3, 5, 5);
        Tomato tomato = new Tomato(40, 70, 4, 6, 7);
        Sunflower sunflower = new Sunflower(20, 40, 2, 4, 3);

        List<Product> chosenProducts = new List<Product>();

        chosenProducts.Add(tomato);
        chosenProducts.Add(sunflower);

        int totalCost = 0;
        for (int i = 0; i < chosenProducts.Count; i++)
        {
            totalCost += chosenProducts[i].Cost;
        }

        if (totalCost > player.Reward)
        {
            throw new InvalidOperationException("Not enough points to buy");
        }

        player.DeductReward(totalCost);

        for (int i = 0; i < chosenProducts.Count; i++)
        {
            chosenProducts[i].Seed();

            

            if (chosenProducts[i] is ICare careableProduct)
            {
                careableProduct.Feed();
                careableProduct.ProvideWater();
            }

            chosenProducts[i].Harvest();
            int profit = chosenProducts[i].Value - chosenProducts[i].TotalCost;
            Console.WriteLine("Profit: " +profit);
            player.AddReward(profit);
        }
    }
}