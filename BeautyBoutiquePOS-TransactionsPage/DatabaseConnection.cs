namespace BeautyBoutiquePOS_TransactionsPage
{
    internal class DatabaseConnection
    {

        private const string Server = "localhost";
        private const string Database = "test";
        private const string Username = "root";
        private const string Password = "root1234";


        public static string GetConnectionString()
        {
            return $"Server={Server};Database={Database};Uid={Username};Pwd={Password};";
        }
    }
}
