/* CSHARP OOP SHOP
 * by Francesco Limpias
 */

namespace csharp_oop_shop
{
    internal class Program
    {
        //My shop
        static Shop mcDonald;
        static List<Shop.Product> products = new List<Shop.Product>();
        static void Main(string[] args)
        {

            //Instantiate the shop
            mcDonald = new Shop("McDonald's");

            products.Add(mcDonald.RegisterNewProduct("CrispyMcBacon", 8, 6));
            products.Add(mcDonald.RegisterNewProduct("ChickenWings", 4, 6));
            products.Add(mcDonald.RegisterNewProduct("CocaCola", 4, 8));

            foreach(Shop.Product p in products)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}