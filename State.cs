using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* WARNING!
 * 
 * this class'methods are not meant to be directly accessed,
 * instead they should be accessed "underground" by Shop and Product classes.
 * 
 */

namespace csharp_oop_shop
{

    public class State
    {

        //STATE PROPERTIES
        //All stored data (by type, like tables in a database)
        private List<Shop> _shops = new();
        public List<Shop> Shops {
            get
            {
                return new List<Shop>(_shops);
            } 

            set
            {
                _shops = value;
            } 
        }

        private List<Product> _products = new();
        public List<Product> Products {
            get
            {
                return new List<Product>(_products);
            }

            set
            {
                _products = value;
            }
        }


        //empty constructor
        public State()
        { }


        //SHOPS VALIDATIONS
        //Attempt to retrieve a shop by a given guid
        public Shop? GetShopByGuid(Guid guid)
        {
            return GuidUtils.GetElementByGuid(Shops, guid);
        }
        //Attempt to store a shop (validation based on guid uniqueness)
        public void AddShop(Shop shop)
        {
            GuidUtils.AddElement(_shops, shop);
        }


        //PRODUCTS VALIDATIONS
        //Attempt to retrieve a product by a given guid
        public Product? GetProductByGuid(Guid guid)
        {
            return GuidUtils.GetElementByGuid(Products, guid);
        }
        //Attempt to store a product (validation based on guid uniqueness)
        public void AddProduct(Product product)
        {
            GuidUtils.AddElement(_products, product);
        }
    }
}