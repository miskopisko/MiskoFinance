using System;
using System.Collections;
using System.Reflection;
using MPersist.Core.Data;
using MPersist.Core.Resources;

namespace MPersist.Core.Tools
{
    public class MPCache
    {
        private static Logger Log = Logger.GetInstance(typeof(MPCache));

        #region Variable Declarations

        private static Boolean Enabled_ = true;
        private static MPCache INSTANCE_;

        private Hashtable CACHE_;

        #endregion

        #region Properties

        public static Boolean Enabled 
        { 
            get { return Enabled_; }
            set { Enabled_ = value; }
        }

        private static MPCache INSTANCE
        {
            get
            {
                if (INSTANCE_ == null)
                {
                    INSTANCE_ = new MPCache();
                }
                return INSTANCE_;
            }
        }

        #endregion

        #region Constructors

        public MPCache()
        {
            CACHE_ = new Hashtable();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static String GetKey(AbstractStoredData storedObject, Object[] keyParts)
        {
            String key = "";

            key += storedObject.GetType().Name + "=>";

            if((keyParts.Length % 2) != 0)
            {
                throw new MPException(typeof(MPCache), MethodInfo.GetCurrentMethod(), ErrorStrings.errCacheKeypairMismatch);
            }

            for (int i = 0; i < keyParts.Length; i=i+2)
            {
                key += keyParts[i].ToString() + ":" + keyParts[i+1].ToString() + ";";
            }

            return key;
        }

        public static void Remove(String key)
        {
            if (Enabled_)
            {
                if (INSTANCE.CACHE_.Contains(key))
                {
                    INSTANCE.CACHE_.Remove(key);
                }
            }
        }

        public static void Put(String key, Object value)
        {
            if(Enabled_)
            {
                if (!INSTANCE.CACHE_.Contains(key))
                {
                    INSTANCE.CACHE_.Add(key, value);
                }
                else
                {
                    INSTANCE.CACHE_[key] = value;
                }
            }
        }

        public static Object Get(String key)
        {
            if(Enabled_)
            {
                return INSTANCE.CACHE_[key];
            }
            else
            {
                return null;
            }
        }

        public static void Flush()
        {
            if(Enabled_)
            {
                INSTANCE.CACHE_.Clear();
            }
        }

        #endregion
    }
}
