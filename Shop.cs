using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{

    internal class Shop
    {
        //The shop name (e.g: "McDonald, Despar, Wallmart, ...)
        private string shopName;

        /* The list of registered codes
         * 
         * Products' code are unique
         * so each shop has to
         * register all its "active" codes
         * to avoid repetitions
         */
        public List<int> registeredCodes;

        /* The Random instance used to
         * generate new codes
         */
        private Random randomCodeGenerator;

        public Shop(string shopName)
        {
            //Save parameters
            this.shopName = shopName;

            //Instantiate the required class attributes
            registeredCodes = new List<int>();
            randomCodeGenerator = new Random();
        }

        //Details getters
        public string GetName()
        {
            return shopName;
        }
        public bool HasCode(int uniqueCode)
        {
            return registeredCodes.Contains(uniqueCode);
        }

        /* GenerateCode()
         * using a Random generator 
         * this function returns a new
         * available code for use
         */
        private int GenerateCode()
        {
            int newCode;
            do
            {
                newCode = randomCodeGenerator.Next();
            } while (HasCode(newCode)); //check if code has already been used

            return newCode;
        }

        /* RegisterNewProduct(...args[], int? uniqueCode)
         * 
         * this function, given the required Product initial attributes
         * registers the product (adding the required unique product's code)
         * in the shop
         */
        public Product RegisterNewProduct(string name, int price, int iva, int? uniqueCode = null)
        {

            //uniqueCode validation block
            if (uniqueCode == null) //No code? Then generate a new one
            {
                uniqueCode = GenerateCode();
            }
            else if(HasCode((int) uniqueCode)) //Provided code? than check that is acceptable
            {
                throw new Exception($"The provided code has already been used! CODE: {uniqueCode}"); 
            }

            //Register the validated code
            registeredCodes.Add((int) uniqueCode);

            return new Product(name, price, iva, (int) uniqueCode);
        }


        /* Product class
         * 
         * this class represents each product registered
         * in a shop "database"
         * 
         */
        public class Product
        {
            //Product details
            private int uniqueCode;
            public string name, description;
            public float 
                price, /* in euros */
                iva /* percentage */;

            /* Product constructor
             * - the description attribute is optional
             *   and so is not enforced by the product's constructor.
             */
            public Product(
                string name,
                float price, 
                float iva, 
                int uniqueCode
                )
            {
                this.name = name;
                this.price = price;
                this.iva = iva;
                this.uniqueCode = uniqueCode;
            }

            /* advanced getters
             * these are functions that return
             * "dynamic" attributes, calculated
             * from the base "static" attributes
             */
            public string GetFullName()
            {
                return $"[{uniqueCode}]{name}";
            }
            public float GetPrice()
            {
                return price;
            }
            public float GetIVAPrice()
            {
                return price + (price * iva / 100);
            }

            // uniqueCode getter
            public int GetUniqueCode()
            {
                return uniqueCode;
            }

            // Override for Object.toString,
            // so that products have a nice and easy way to be printed on console
            public override string ToString()
            {
                return $"{name}: {GetIVAPrice()}Euro";
            }

        }

    }

}
