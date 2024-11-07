using MySql.Data.MySqlClient;

namespace DemoProject
{
    internal class DatabaseConnection
    {
        private const string CONNECTION_STRING =    // Connection string for MySQL connection
            "server=127.0.0.1;" +
            "database=exampledb;" +
            "uid=root";

        private MySqlConnection _connection;    // Connection to a MySQL Database

        /// <summary>
        /// Setup the DatabaseConnection
        /// </summary>
        private DatabaseConnection()
        {
            _connection = new MySqlConnection(CONNECTION_STRING);
            try
            {
                _connection.Open();
                if (!_connection.Ping())
                    MessageBox.Show("Error: Connection unsuccessful!");
            }
            catch(MySqlException e)
            {
                MessageBox.Show("Error (" + e.Number + "): " + e.Message);
            }
        }
        
        /// <summary>
        /// Close the DatabaseConnection
        /// </summary>
        ~DatabaseConnection()
        {
            _connection.Close();
        }

        #region Singleton Pattern
        private static DatabaseConnection _instance;
        
        /// <summary>
        /// Get the current instance of the Database Connection singleton
        /// </summary>
        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseConnection();
                return _instance;
            }
            private set { }
        }
        #endregion

        #region Generic Commands
        /// <summary>
        /// Run a non-query MySQL command
        /// </summary>
        /// <param name="sql">Non-query MySQL command to run</param>
        public void NonQuery(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Run a MySQL query
        /// </summary>
        /// <param name="sql">MySQL Query to run</param>
        /// <returns>MySqlDataReader object containing results of query</returns>
        public MySqlDataReader Query(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            return cmd.ExecuteReader();
        }
        #endregion
    }
}