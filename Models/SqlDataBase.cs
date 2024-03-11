using ProjectMateApp.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProjectMateApp.Models
{
    public class SqlDataBase : IDataBase
    {
        private const string ConnectionConfig = @"Data Source=.;Initial Catalog=STPDatabase;Trusted_Connection=True;";

        private SqlConnection _sqlConnection;

        public IEnumerable<Manager> Managers
        {
            get
            {
                DataTable table = Query("SELECT * FROM Managers");

                List<Manager> managers = new List<Manager>(0);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    Manager manager = new Manager((string)row.ItemArray[1]);
                    managers.Add(manager);
                }

                return managers;
            }
        }

        public IEnumerable<Client> Clients
        {
            get
            {
                DataTable table = Query("SELECT * FROM Clients");

                List<Client> clients = new List<Client>(0);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    string name = (string)row.ItemArray[1];
                    ClientStatus status = (ClientStatus)row.ItemArray[2];
                    Manager manager = new Manager("");

                    Client client = new Client(name, status, manager);
                    clients.Add(client);
                }

                return clients;
            }
        }

        public IEnumerable<Product> Products
        {
            get
            {
                DataTable table = Query("SELECT * FROM Products");

                List<Product> products = new List<Product>(0);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    string name = (string)row.ItemArray[1];
                    int price = (int)row.ItemArray[2];
                    ProductType type = (ProductType)row.ItemArray[3];
                    DateTime expiration = (DateTime)row.ItemArray[4];

                    Product manager = new Product(name, price, type, expiration);
                    products.Add(manager);
                }

                return products;
            }
        }

        public SqlDataBase()
        {
            _sqlConnection = new SqlConnection(ConnectionConfig);
            _sqlConnection.Open();
        }

        public void Add(Manager manager)
        {
            // Check if exists
            Query($"INSERT INTO Managers VALUES ('{manager.Name}')");
        }

        public void Add(Product product)
        {
            Query($"INSERT INTO Products VALUES ('{product.Name}', '{product.Price}', '{(int)product.Type}', '{product.SubscriptionExpirationDate}')");
        }

        public void Add(Client client)
        {
            Query($"INSERT INTO Clients VALUES ('{client.Name}', '{(int)client.Status}')");
        }

        public void Delete(Manager manager)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client client)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Manager manager)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Managers WHERE ([FullName] = '{manager.Name}')", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            bool result = reader.HasRows;

            command.Dispose();
            reader.Close();
            reader.Dispose();

            return result;
        }

        public bool Exists(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Client client)
        {
            throw new NotImplementedException();
        }

        private DataTable Query(string sqlQuery)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(sqlQuery, _sqlConnection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            command.Dispose();
            return table;
        }
    }
}
