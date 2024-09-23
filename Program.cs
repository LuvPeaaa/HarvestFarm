using HarvestFarm;
using System;

class Program
{
    public static void Main()
    {
        Player player = new Player("TBB", 100);

        List<Product> products = new List<Product>();

        products.Add(new Wheat(30, 50, 3, 5, 5));
        products.Add(new Tomato(40, 90, 4, 6, 7));
        products.Add(new Sunflower(20, 60, 2, 4, 3));

        List<Product> chosenProducts = new List<Product>();

        Console.WriteLine("Choose your plant or enter 0 to end");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].GetType().Name} (Cost: {products[i].Cost}, Value: {products[i].Value})");
        }

        int totalCost = 0;
        while (true)
        {
            Console.WriteLine("Choose the plant you want from 1 to 3");
            string input = Console.ReadLine();
            int choice;
            bool validChoice = int.TryParse(input, out choice);
            if (!validChoice || choice < 0 || choice > products.Count)
            {
                Console.WriteLine("Choose again!");
                continue;
            }
            if (choice == 0)
            {
                break;
            }

            Product selectedProduct = products[choice - 1];
            if (totalCost + selectedProduct.Cost > player.Reward)
            {
                Console.WriteLine("Not enough points to buy this");
                continue;
            }
            chosenProducts.Add(selectedProduct);
            totalCost += selectedProduct.Cost;

            Console.WriteLine($"{selectedProduct.GetType().Name} has been added to your inventory.");

            Console.WriteLine("\nList of your choice");           
            foreach (Product product in chosenProducts)
            {
                Console.WriteLine(product.GetType().Name);
            }
        }

        if (totalCost > 0)
        {
            player.DeductReward(totalCost);
            Console.WriteLine($"You have spent {totalCost} points. Your remaining points: {player.Reward}");
        }
        else
        {
            Console.WriteLine("You haven't chosen any products.");
        }


        

        //Planting process
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