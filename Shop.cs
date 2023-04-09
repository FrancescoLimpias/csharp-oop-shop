using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{

    internal class Shop
    {

        //Shop IDs
        private Guid guid = new Guid();
        private List<Guid> productsGuids = new List<Guid>();

        //Shop details
        public string name, description;

        /* CONSTRUCTORS
         * 1) base constructor that allows for creation of NEW shops
         *      1.5) save function that allows for storage of NEW shops
         * 2) function based "constructor" that allows for EXISTENT shops retrieval
         */
        public Shop(string shopName)
        {
            //save details
            this.shopName = shopName;
        }
        public Shop save()
        {
            currentState.addShop(this);
            return this;
        }

        public Shop find(Guid guid)
        {
            return currentState.getShop(guid);
        }

        //Details getters
        public bool HasProduct(Product product)
        {
            return productsGuids.Contains(product.guid);
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
                newCode = randomCodeGenerator.Next(GetMaxCodeValue());
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
            else if (HasCode((int)uniqueCode)) //Provided code? than check that is acceptable
            {
                throw new Exception($"The provided code has already been used! CODE: {uniqueCode}");
            }
            int code = (int)uniqueCode;

            //Register the validated code
            registeredCodes.Add(code);

            return new Product(this, name, price, iva, code);
        }




    }

}
