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
     */
    internal class Product
    {
        //Product IDs
        private Guid parentShopGuid;
        private Guid guid = new Guid();

        //Product details
        public string name, description;
        public float
            price, /* in euros */
            iva /* a percentage */;

        /* Product constructor
         * - the description attribute is optional
         *   and so is not enforced by the product's constructor.
         */
        public Product(
            Shop parentShop,
            string name,
            float price,
            float iva,
            )
        {
            this.ParentShop = parentShop.guid;
            this.name = name;
            this.price = price;
            this.iva = iva;
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

        // GUID getters
        public Guid GetUniqueCode()
        {
            return guid;
        }

        /* DEPRECATED use
         * as Guid identifiers have substituted old 'integer based' identifiers
         * this "normalizing" function lost meaning, now it's kept just for legacy code.
         */
        public string GetPaddedUniqueCode()
        {
            //Cast the code into a string type
            string castedCode = guid.ToString();

            //Check if code is not too long
            /* FROM OLD IMPLEMENTATION, KEPT JUST IN CASE...
            if (castedCode.Length > ParentShop.GetUniqueCodePadding())
            {
                throw new Exception($"The code is too long! CODE: {castedCode}");
            }
            */

            //Grow the string until it is long enough
            //for the requested padding
            /*
            while (castedCode.Length < ParentShop.UniqueCodePadding)
                castedCode = "0" + castedCode;
            */

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