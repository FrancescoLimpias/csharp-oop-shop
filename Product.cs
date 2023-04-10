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
    public class Product : GuidIdentified
    {

        //PRODUCT's PROPERTIES
        //Product IDs
        public Guid parentShopGuid { private set; get; }
        public Guid guid { private set; get; } = new Guid();

        //Product details
        public string name, description;
        public string fullName => $"[{/*GetPaddedUniqueCode()*/"DEBUG PADDING!"}]{name}";

        //Product prices
        public float 
            price, // euros
            iva; // percentage
        public float ivaPrice => price + (price * iva / 100); // euros


        /* PRODUCT CONSTRUCTOR
         * - the description attribute is optional
         *   and so is not enforced by the product's constructor.
         */
        public Product(
            Shop parentShop,
            string name,
            float price,
            float iva
            )
        {
            this.parentShopGuid = parentShop.guid;
            this.name = name;
            this.price = price;
            this.iva = iva;
        }

        // Override for Object.toString,
        // so that products have a nice and easy way to be printed on console
        public override string ToString()
        {
            return $"{fullName}: {ivaPrice}Euro";
        }
    }
}