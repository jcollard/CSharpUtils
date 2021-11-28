namespace CaptainCoder
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    
    public class Utils
    {

        public static readonly Utils Instance = new Utils();

        private Utils()
        {
            
        }

        /// <summary>
        /// Given a string, return an IEnumerable of each line in the string.
        /// </summary>
        /// <param name="text">The string to be enumerated.</param>
        /// <returns>An IEnumerable of strings</returns>
        public IEnumerable<String> GetStringIterable(string text)
        {
            string line;
            using StringReader reader = new StringReader(text);
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }

            reader.Close();
        }

        /// <summary>
        /// Given a Dictionary, returns an IEnumerable of key value pairs in a dictionary.
        /// </summary>
        /// <param name="dict">The dictionary to enumerate.</param>
        /// <typeparam name="K">The key type of the dictionary.</typeparam>
        /// <typeparam name="V">The value type of the dictionary.</typeparam>
        /// <returns>An enumeration of pair of key values.</returns>
        public IEnumerable<(K, V)> GetKeyValueEnumerable<K, V>(Dictionary<K, V> dict)
        {
            foreach (K key in dict.Keys)
            {
                yield return (key, dict[key]);
            }
        }

        /// <summary>
        /// Given an IEnumerable of key value pairs, construct a dictionary.
        /// The returned dictionary references the keys and values in the data and does not copy them.
        /// If there are two identical keys in the data provided, the value for that key in the returned dictionary
        /// is undefined.
        /// </summary>
        /// <param name="data">The data to convert to a dictionary.</param>
        /// <typeparam name="K">The type of the keys.</typeparam>
        /// <typeparam name="V">The type of the values.</typeparam>
        /// <returns>A dictionary containing the key value pairs specified.</returns>
        public Dictionary<K, V> ToDict<K, V>(IEnumerable<(K, V)> data)
        {
            Dictionary<K, V> d = new Dictionary<K, V>();
            if (data == null)
            {
                return d;
            }
            foreach ((K key, V value) in data)
            {
                d[key] = value;
            }
            return d;
        }

        /// <summary>
        /// Given an array, returns an IEnumerable containing the index, value
        /// pair for each element in the array.
        /// </summary>
        /// <param name="arr">The array to enumerate.</param>
        /// <typeparam name="T">The type of the data in the array.</typeparam>
        /// <returns>An IEnumerable of the data in the array.</returns>
        public static IEnumerable<(int, T)> GetIndexEnumerable<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return (i, arr[i]);
            }
        }

        /// <summary>
        /// Given a two dimensional array, returns an IEnumerable containing the indices and value
        /// for each element in the array.
        /// </summary>
        /// <param name="arr">The 2D array.</param>
        /// <typeparam name="T">The type of the data stored in the array.</typeparam>
        /// <returns>An IEnumerable of the data in the array/</returns>
        public IEnumerable<(int, int, T)> Get2DEnumerable<T>(T[,] arr)
        {
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                for (int c = 0; c < arr.GetLength(1); c++)
                {
                    yield return (r, c, arr[r, c]);
                }
            }
        }
    }
}