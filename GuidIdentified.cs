using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{
    public interface GuidIdentified
    {
        public Guid guid { get; }
    }

    public static class GuidUtils
    {

        /* GUID Utility methods
         * this methods are the generic (literally) implementation
         * of validation for all types that have a guid based identification.
         */
        public static T? GetElementByGuid<T>(List<T> list, Guid guid) where T : GuidIdentified?
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

        public static void AddElement<T>(List<T> list, T element) where T : GuidIdentified?
        {
            if (
                list.Contains(element)  //there is an instance of this element already
                || GetElementByGuid(list, element.guid) != null) //the element guid has already been registered
            {
                throw new Exception("Element already registered!");
            }

            list.Add(element);
        }
    }
}
