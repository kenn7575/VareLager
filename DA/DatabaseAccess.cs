namespace DA
{
    public class DatabaseAccess
    {
        //fields
        private string? ConnectionString;

        //Methods
        public DatabaseAccess()
        {
            ConnectionString = 
                "Server=10.130.54.79;" +
                "Database=Varelager;" +
                "Uid=sa;" +
                "Password=1234";
        }
    }
}