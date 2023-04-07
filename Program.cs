/* CSHARP OOP SHOP
 * by Francesco Limpias
 */

namespace csharp_oop_shop
{
    internal class Program
    {
        //My shop
        static Shop mcDonald;
        static Shop.Product[] products; 
        //static List<Shop.Product> products = new List<Shop.Product>();
        static void Main(string[] args)
        {

            //Instantiate the shop
            mcDonald = new Shop("McDonald's");
            products = new Shop.Product[5];

            products[0] = mcDonald.RegisterNewProduct("Crispy McBacon", 8, 6);
            products[1] = mcDonald.RegisterNewProduct("Chicken Wings", 5, 9);
            products[2] = mcDonald.RegisterNewProduct("CocaCola", 10, 2);
            products[3] = mcDonald.RegisterNewProduct("Tasty Bucket", 20, 40);
            products[4] = mcDonald.RegisterNewProduct("Mc Flurry", 32, 18);

            foreach(Shop.Product product in products)
            {
                Console.WriteLine(product);
            }

            /*
            products.Add(mcDonald.RegisterNewProduct("CrispyMcBacon", 8, 6));
            products.Add(mcDonald.RegisterNewProduct("ChickenWings", 4, 6));
            products.Add(mcDonald.RegisterNewProduct("CocaCola", 4, 8));
            */

            foreach (Shop.Product p in products)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}