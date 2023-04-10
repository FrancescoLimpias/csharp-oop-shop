using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{
    public interface IGuidIdentified
    {
        public Guid Guid { get; }
    }

    public static class GuidUtils
    {

        /* GUID Utility methods
         * this methods are the generic (literally) implementation
         * of validation for all types that have a guid based identification.
         */
        public static T? GetElementByGuid<T>(List<T> list, Guid guid) where T : IGuidIdentified
        {
            try
            {
                return list.First(evaluatedElement => evaluatedElement.Guid == guid);
            }
            catch (InvalidOperationException)
            {
                return default; //in other words, NULL
            }
        }

        public static void AddElement<T>(List<T> list, T element) where T : IGuidIdentified
        {
            if (
                list.Contains(element)  //there is an instance of this element already
                || GetElementByGuid(list, element.Guid) != null) //the element guid has already been registered
            {
                throw new Exception("Element already registered!");
            }

            list.Add(element);
        }
    }
}
