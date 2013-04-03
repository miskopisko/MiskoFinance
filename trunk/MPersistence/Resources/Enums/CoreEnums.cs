namespace MPersist.Resources.Enums
{
    public enum SessionType
    {
        NULL = -1,
        Oracle = 0,
        MySql = 1,
        Sqlite = 2
    }

    public enum SqlType
    {
        NULL = -1,
        SQL = 0,
	    Procedure = 1,
	    Function = 2
    }

    public enum UpdateMode
    {
        NULL = -1,
        Insert = 0,
        Update = 1,
        Delete = 2
    }

    public enum Gender
    {
        NULL = -1,
        Male = 0,
        Female = 1
    }

    public enum Language
    {
        NULL = -1,
        English = 0,
        French = 1
    }

    public enum ErrorLevel
    {
        NULL = -1,
        Critical = 0,
        Warning = 1,
        Technical = 2,
        Timeout = 3
    }
}