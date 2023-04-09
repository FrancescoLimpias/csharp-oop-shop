using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{

    internal class Shop
    {
        //The shop name (e.g: "McDonald, Despar, Wallmart, ...)
        private string shopName;

        private int UniqueCodePadding = 8;

        /* The list of registered codes
         * 
         * Products' code are unique
         * so each shop has to
         * register all its "active" codes
         * to avoid repetitions
         */
        public List<int> registeredCodes;

        /* The Random instance used to
         * generate new codes
         */
        private Random randomCodeGenerator;

        public Shop(string shopName)
        {
            //Save parameters
            this.shopName = shopName;

            //Instantiate the required class attributes
            registeredCodes = new List<int>();
            randomCodeGenerator = new Random();
        }

        //Details getters
        public string GetName()
        {
            return shopName;
        }
        public bool HasCode(int uniqueCode)
        {
            return registeredCodes.Contains(uniqueCode);
        }
        public int GetUniqueCodePadding()
        {
            return UniqueCodePadding;
        }
        private int GetMaxCodeValue()
        {
            string maxValue = "";

            while (maxValue.Length < GetUniqueCodePadding())
                maxValue += "9";

            return Convert.ToInt32(maxValue);
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
