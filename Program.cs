/* CSHARP OOP SHOP
 * by Francesco Limpias
 */

namespace csharp_oop_shop
{

    public class Program
    {

        //"Clearfix" implementation of a current state
        public static State currentState = new State();

        static void Main(string[] args)
        {

            //Instantiate a shop
            Shop mcDonald = new Shop("McDonald's").save();
            Console.WriteLine(mcDonald.name);

            //Save shop's Guid for later referral
            Guid mcDonaldGuid = mcDonald.guid;

            //Retrieve same shop by Guid
            Shop otherMcDonald = Shop.find(mcDonaldGuid);
            Console.WriteLine(otherMcDonald.name);

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