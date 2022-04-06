using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasManPC.Core.Extention
{
    public static class Extentions
    {
        public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic,
                                      TKey oldKey, TKey newKey)
        {
            if (oldKey.Equals( newKey)) return;
            if (dic.ContainsKey(newKey)) throw new ArgumentException("NewKey alradey exists");
            TValue value = dic[oldKey];
            dic.Remove(oldKey);
            dic[newKey] = value;
        }
        public static void ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dic,
                                     TKey oldKey, TKey newKey)
        {
            TValue value = dic[oldKey];
            dic.Remove(oldKey);
            dic[newKey] = value;
        }

        public static string Repeat(this char str, int times)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(str, times);

            return builder.ToString();
        }

        public static void Append(this MemoryStream stream, byte value)
        {
            stream.Append(new[] { value });
        }

        public static void Append(this MemoryStream stream, byte[] values)
        {
            stream.Write(values, 0, values.Length);
        }
        public static void Append(this MemoryStream stream, string values)
        {
            stream.Write(Encoding.Default.GetBytes(values), 0, values.Length);
        }
        public static void Append(this MemoryStream stream, int values)
        {
            stream.Append(BitConverter.GetBytes(values));
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
