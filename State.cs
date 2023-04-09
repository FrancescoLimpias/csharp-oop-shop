using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* WARNING!
 * 
 * this class'methods are not meant to be directly accessed,
 * instead they should be "underground" accessed by Shop and Product classes.
 * 
 */

namespace csharp_oop_shop
{

    //All stored data (by type, like tables in a database)
    private List<Shop> shops = new List<Shop>();
    private List<Product> products = new List<Product>();

    public class State
    {
        public State()
        {
        }

        //Attempt to retrieve a shop by a given guid
        public Shop getShopByGuid(Guid guid)
        {
            return shops.First(evShop => evShop.guid == shop.guid);
        }

        //Attempt to store a shop (validation based on guid uniqueness)
        public void addShop(Shop shop)
        {
            if(
                shops.Contains(shop)  //there is an instance of this shop already
                || getShopByGuid(shop) != null) //the shop guid has already been registered
            {
                throw new Exception("Shop already registered!")
            }

            shops.add(shop);
        }
    }

}