﻿/* CSHARP OOP SHOP
 * by Francesco Limpias
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace csharp_oop_shop
{

    public class Program
    {

        //"Clearfix" implementation of a current state
        internal static State currentState = new();

        static void Main(string[] args)
        {

            //Instantiate a shop
            Shop mcDonald = new Shop("McDonald's");

            //Save shop reference for later use
            Guid mcDonaldGuid = mcDonald.Guid;

            //Add some products
            new Product(mcDonald, "Crispy McBacon", 8, 6);
            new Product(mcDonald, "Chicken Wings", 5, 9);
            new Product(mcDonald, "CocaCola", 10, 2);
            new Product(mcDonald, "Tasty Bucket", 20, 40);
            new Product(mcDonald, "McFlurry", 32, 18);

            //Log everything
            Console.WriteLine(mcDonald.ToString());
            Console.WriteLine(mcDonald.ProductsToString());

            //STATE CHANGE
            SimulateStateChange();

            Console.WriteLine(currentState.Products.Count);

            //attempt to retrieve mcDonald by Guid reference
            Shop newMcDonaldReference = Shop.Find(mcDonaldGuid);

            //Log everything (again)
            Console.WriteLine(newMcDonaldReference.ToString());
            Console.WriteLine(newMcDonaldReference.ProductsToString());

        }

        private static void SimulateStateChange()
        {
            //Console.WriteLine(JsonSerializer.Serialize(currentState));
            currentState = JsonSerializer.Deserialize<State>(JsonSerializer.Serialize(currentState));
        }
    }
}