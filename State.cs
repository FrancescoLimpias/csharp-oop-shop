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
        private List<Shop> shops { get; set; } = new List<Shop>();
        private List<Product> products { get; set; } = new List<Product>();


        //empty constructor
        public State()
        { }


        /* STATE PRIVATE METHODS
         * this methods are the generic (literally) implementation
         * of validation for all types that have a guid based identification.
         */
        private T? GetElementByGuid<T>(List<T> list, Guid guid) where T : GuidIdentified?
        {
            try
            {
                return list.First(evaluetedElement => evaluetedElement.guid == guid);
            }
            catch (InvalidOperationException)
            {
                return default(T); //in other words, NULL
            }
        }

        private void AddElement<T>(List<T> list, T element) where T : GuidIdentified?
        {
            if (
                list.Contains(element)  //there is an instance of this element already
                || GetElementByGuid(list, element.guid) != null) //the element guid has already been registered
            {
                throw new Exception("Element already registered!");
            }

            list.Add(element);
        }


        //SHOPS VALIDATIONS
        //Attempt to retrieve a shop by a given guid
        public Shop? GetShopByGuid(Guid guid)
        {
            return GetElementByGuid(shops, guid);
        }
        //Attempt to store a shop (validation based on guid uniqueness)
        public void AddShop(Shop shop)
        {
            AddElement(shops, shop);
        }


        //PRODUCTS VALIDATIONS
        //...
    }

}