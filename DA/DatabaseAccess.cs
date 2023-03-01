namespace DA
{
    public class DatabaseAccess
    {
        //Constructor
        public DatabaseAccess()
        {
            ConnectionString = 
                "Server=10.130.54.79;" +
                "Database=Varelager;" +
                "Uid=sa;" +
                "Password=1234";
        }
        
        //fields
        protected string? ConnectionString;
    }
}