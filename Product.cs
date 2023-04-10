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
    public class Product : IGuidIdentified
    {

        //PRODUCT's PROPERTIES
        //Product IDs
        public Guid ShopGuid { private set; get; }
        public Shop shop => Program.currentState.GetShopByGuid(ShopGuid);
        public Guid Guid { private set; get; } = Guid.NewGuid();

        //Product details
        public string name, description = "";
        public string FullName => $"[{Guid}]{name}";

        //Product prices
        public float 
            price, // euros
            iva; // percentage
        public float IvaPrice => price + (price * iva / 100); // euros


        /* PRODUCT CONSTRUCTOR
         * 1) base constructor that allows for creation and storage of NEW products
         * 2) function based "constructor" that allows for EXISTENT products retrieval
         * 
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
            ShopGuid = parentShop.Guid;
            this.name = name;
            this.price = price;
            this.iva = iva;

            Program.currentState.AddProduct(this);
        }

        public static Product? Find(Guid guid)
        {
            return Program.currentState.GetProductByGuid(guid);
        }

        // Override for Object.toString,
        // so that products have a nice and easy way to be printed on console
        public override string ToString()
        {
            return $"{FullName}: {IvaPrice}Euro";
        }
    }
}