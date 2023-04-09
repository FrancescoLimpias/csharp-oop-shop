/* CSHARP OOP SHOP
 * by Francesco Limpias
 */

namespace csharp_oop_shop
{
    //"Clearfix" implementation of a current state
    static State currentState = new State();

    internal class Program
    {
        //My shop
        static Shop mcDonald;
        //static Shop.Product[] products; 

        static void Main(string[] args)
        {

            //Instantiate the shop
            mcDonald = new Shop("McDonald's").save();

            /*
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
            */
        }
    }
}