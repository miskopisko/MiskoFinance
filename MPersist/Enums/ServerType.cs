using System;

namespace MPersist.Enums
{
    public class ServerType : AbstractEnum
    {
        #region Fields

        private static readonly ServerType mNULL_ = new ServerType(-1, "", "");
        private static readonly ServerType mLocal_ = new ServerType(0, "", "Local");
        private static readonly ServerType mOnline_ = new ServerType(1, "", "Online");

        private static readonly ServerType[] mElements_ = new[]
		{
		    mNULL_, mLocal_, mOnline_
		};

        #endregion

        #region Parameters

        public static ServerType[] Elements { get { return mElements_; } }
        public static ServerType NULL { get { return mNULL_; } }
        public static ServerType Local { get { return mLocal_; } }
        public static ServerType Online { get { return mOnline_; } }

        #endregion

        #region Constructors

        protected ServerType()
        {
        }

        protected ServerType(Int64 value, String code, String description)
            : base(value, code, description)
        {
        }

        #endregion

        #region Helpers

        public static ServerType GetElement(long index)
        {
            for (int i = 0; Elements != null && i < Elements.Length; i++)
            {
                if (Elements[i].Value == index)
                {
                    return Elements[i];
                }
            }

            return null;
        }

        public static ServerType GetElement(String descriptionCode)
        {
            for (int i = 0; descriptionCode != null && Elements != null && i < Elements.Length; i++)
            {
                if (Elements[i].Description.ToLower().Equals(descriptionCode.ToLower()) || Elements[i].Code.ToLower().Equals(descriptionCode.ToLower()))
                {
                    return Elements[i];
                }
            }

            return null;
        }

        #endregion
    }
}