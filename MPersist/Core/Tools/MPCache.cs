using System;
using System.Collections;
using MPersist.Core.Resources;

namespace MPersist.Core.Tools
{
    public class MPCache
    {
        private static Logger Log = Logger.GetInstance(typeof(MPCache));

        #region Fields
                
        private static Hashtable mCache_;
        private static Boolean mEnabled_ = true;

        #endregion

        #region Properties

        public static Boolean Enabled { get { return mEnabled_; } set { mEnabled_ = value; } }

        private static Hashtable Cache
        {
            get
            {
                if (mCache_ == null)
                {
                    mCache_ = new Hashtable();
                }
                return mCache_;
            }
        }

        #endregion

        #region Constructors

        public MPCache()
        {
            mCache_ = new Hashtable();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static String GetKey(Type storedObject, String connectionName, Object[] keyParts)
        {
            String key = "";

            key += connectionName + "." + storedObject.Name + "=>";

            if((keyParts.Length % 2) != 0)
            {
                throw new MPException(ErrorStrings.errCacheKeypairMismatch);
            }

            for (int i = 0; i < keyParts.Length; i=i+2)
            {
                String keyPart = keyParts[i].ToString();
                String keyPartValue = keyParts[i + 1] != null ? keyParts[i + 1].ToString() : "";
                key += keyPart + ":" + keyPartValue + ";";
            }

            return key;
        }

        public static void Remove(String key)
        {
            if (mEnabled_)
            {
                if (Cache.Contains(key))
                {
                    Cache.Remove(key);
                }
            }
        }

        public static void Put(String key, Object value)
        {
            if(Enabled)
            {
                if (!Cache.Contains(key))
                {
                    Cache.Add(key, value);
                }
                else
                {
                    Cache[key] = value;
                }
            }
        }

        public static Object Get(String key)
        {
            if (Enabled)
            {
                return Cache[key];
            }
            else
            {
                return null;
            }
        }

        public static void Flush()
        {
            if (Enabled)
            {
                Cache.Clear();
            }
        }

        #endregion
    }
}
