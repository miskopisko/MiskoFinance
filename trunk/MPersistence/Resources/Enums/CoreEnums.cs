namespace MPersist.Resources.Enums
{
    public enum SessionType
    {
        Oracle = 0,
        MySql = 1,
        Sqlite = 2
    }

    public enum SqlType
    {
        SQL = 0,
	    Procedure = 1,
	    Function = 2
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum Language
    {
        English = 0,
        French = 1
    }

    public enum ErrorLevel
    {
        Critical = 0,
        Warning = 1,
        Technical = 2,
        Timeout = 3
    }
}