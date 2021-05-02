using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

using Newtonsoft.Json;

namespace HelpfulLibrary
{
    public static class HelpfulExtensions
    {
        /// <summary>
        /// Инициализирует строковые и целочисленные свойства указанного объекта.
        /// </summary>
        public static T InitStringAndIntProps<T>(this T obj, int? numberAfterName = null)
        {
            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                var propType = prop.PropertyType;

                if (propType == typeof(string))
                    prop.SetValue(obj, $"{prop.Name}{numberAfterName}");
                else if (propType == typeof(int))
                    prop.SetValue(obj, numberAfterName ?? 0);
            }

            return obj;
        }

        public static int ToInt32(this BigInteger bigInteger)
        {
            return int.Parse(bigInteger.ToString());
        }

        /// <summary>
        /// Возвращает строковое представление значений всех публичных свойств объекта.
        /// </summary>
        public static string ToStringProperties<T>(this T obj, string sep = ";")
        {
            if (obj == null) 
                return $"{typeof(T).Name} = null{sep}";
            var result = new StringBuilder().AppendLine($"Type = {typeof(T).Name}. Props to string:");

            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
                result.AppendLine($"{prop.Name} = {JsonConvert.SerializeObject(prop.GetValue(obj), Formatting.None)}{sep}");

            return result.ToString();
        }

        public static T RandomElement<T>(this IEnumerable<T> iEnum, Random rnd = null, int? first = null, int? last = null)
        {
            if (iEnum == null || iEnum.Count() == 0) 
                return default;

            var internalRnd = rnd ?? new Random(Environment.TickCount);

            var internalFirst = first != null ? first.Value : 0;
            if (internalFirst < 0)
                internalFirst = 0;
            
            var internalLast = last != null ? last.Value : iEnum.Count();
            if (iEnum.Count() <= internalLast)
                internalLast = iEnum.Count() - 1;

            if (internalFirst > internalLast)
                HelpfulMethods.SwapValues(ref internalFirst, ref internalLast);

            var elIndex = internalRnd.Next(internalFirst, internalLast);
            return iEnum.ElementAt(elIndex);
        }

        public static IEnumerable<char> AddFromTo(this IEnumerable<char> charArray, char from, char to)
        {
            var result = charArray.ToList();
            result.AddRange(HelpfulMethods.FromTo(from, to));
            return result;
        } 
        
        public static T TryConvertTo<T>(this object obj, out bool isSuccess)
        {
            try
            {
                isSuccess = true;
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch
            {
                isSuccess = false;
                return default;
            }
        }

        public static T JsonCopy<T>(this T obj) =>
            JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));

        public static string JoinToString<T>(this IEnumerable<T> list, string separator = "; ", params T[] elements)
        {
            var iEnum = list.Select(x => x.ToString()).ToList();
            iEnum.AddRange(elements?.Select(x => x.ToString()));
            return string.Join(separator, iEnum);
        }
    }
}
