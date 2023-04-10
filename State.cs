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

        //All stored data (by type, like tables in a database)
        private List<Shop> shops { get; set; } = new List<Shop>();
        private List<Product> products { get; set; } = new List<Product>();

        public State()
        { }

        //Attempt to retrieve a shop by a given guid
        public Shop GetShopByGuid(Guid guid)
        {
            return shops.First(evShop => evShop.guid == guid);
        }

        //Attempt to store a shop (validation based on guid uniqueness)
        public void AddShop(Shop shop)
        {
            if (
                shops.Contains(shop)  //there is an instance of this shop already
                || GetShopByGuid(shop.guid) != null) //the shop guid has already been registered
            {
                throw new Exception("Shop already registered!");
            }

            shops.Add(shop);
        }
    }

}