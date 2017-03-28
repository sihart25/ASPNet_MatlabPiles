using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSICDemoDec.Utils
{ 
    [Serializable]
    public class JsonDictionary<K, V> : System.Runtime.Serialization.ISerializable
    {
        Dictionary<K, V> dict = new Dictionary<K, V>();

        public JsonDictionary() { }

        protected JsonDictionary(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            foreach (K key in dict.Keys)
            {
                info.AddValue(key.ToString(), dict[key]);
            }
        }

        public void Add(K key, V value)
        {
            dict.Add(key, value);
        }

        public V this[K index]
        {
            set { dict[index] = value; }
            get { return dict[index]; }
        }
    }

}