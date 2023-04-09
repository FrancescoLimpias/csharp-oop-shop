using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{

    /* Product class
     * 
     * this class represents each product registered
     * in a shop "database"
     * 
     */
    internal class Product
    {
        //Product details
        private Shop ParentShop;
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
            Shop parentShop,
            string name,
            float price,
            float iva,
            int uniqueCode
            )
        {
            this.ParentShop = parentShop;
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
            return $"[{GetPaddedUniqueCode()}]{name}";
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
        public string GetPaddedUniqueCode()
        {
            //Cast the code into a string type
            string castedCode = uniqueCode.ToString();

            //Check if code is not too long
            /* FROM OLD IMPLEMENTATION, KEPT JUST IN CASE...
            if (castedCode.Length > ParentShop.GetUniqueCodePadding())
            {
                throw new Exception($"The code is too long! CODE: {castedCode}");
            }
            */

            //Grow the string until it is long enough
            //for the requested padding
            while (castedCode.Length < ParentShop.UniqueCodePadding)
                castedCode = "0" + castedCode;

            return castedCode;
        }

        // Override for Object.toString,
        // so that products have a nice and easy way to be printed on console
        public override string ToString()
        {
            return $"{GetFullName()}: {GetIVAPrice()}Euro";
        }
    }
}