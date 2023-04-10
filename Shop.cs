using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{
    public class Shop : IGuidIdentified
    {

        //SHOP's PROPERTIES
        //Shop IDs
        public Guid Guid { get; private set; } = Guid.NewGuid();

        //Shop details
        public string name, description = "";

        //Shop products
        public List<Product> Products
        {
            get
            {
                return Program.currentState.Products.FindAll(product => product.ShopGuid == Guid);
            }
        }


        /* SHOP CONSTRUCTOR(s)
         * 1) base constructor that allows for creation of NEW shops
         * 2) function based "constructor" that allows for EXISTENT shops retrieval
         */
        public Shop(string name)
        {
            //save details
            this.name = name;

            Program.currentState.AddShop(this);
        }

        public static Shop? Find(Guid guid)
        {
            return Program.currentState.GetShopByGuid(guid);
        }


        //SHOP's METHODS
        //check if a given product is registered
        public bool HasProduct(Guid productGuid)
        {
            return Products.Find(product => product.Guid == productGuid) != null;
        }
        public bool HasProduct(Product product)
        {
            return HasProduct(product.Guid);
        }

        //STRING CONVERSIONS
        public override string ToString()
        {
            return $"[{Guid}]{name}";
        }
        public string ProductsToString()
        {
            return string.Join("\n",
                Products.ConvertAll(new Converter<Product, string>(
                    product => product.ToString()
                )).ToArray());
        }
    }

}
