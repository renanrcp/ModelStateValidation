using System.Collections.Generic;
using System.Linq;

namespace ModelStateValidation
{
    internal static class ContentExtensions
    {
        public static bool HasContent(this object obj)
            => obj != null;

        public static bool HasNoContent(this object obj)
            => !obj.HasContent();

        public static bool HasContent<T>(this IEnumerable<T> obj)
            => obj != null && obj.Count() > 0;

        public static bool HasNoContent<T>(this IEnumerable<T> obj)
            => !obj.HasContent();

        public static bool HasContent<T>(this T[] obj)
            => obj != null && obj.Length > 0;

        public static bool HasNoContent<T>(this T[] obj)
            => !obj.HasContent();
    }
}