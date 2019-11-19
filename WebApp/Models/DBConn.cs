using System;
using System.Data.SqlClient;

namespace WebApp.Models
{
	public class DBConn
	{

		private SqlConnection conn;

		public bool Connect()
		{
			string constr;


			// Data Source is the name of the  
			// server on which the database is stored. 
			// The Initial Catalog is used to specify 
			// the name of the database 
			// The UserID and Password are the credentials 
			// required to connect to the database. 
			constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pgualambo\Source\Repos\ExamenTecnico\WebApp\App_Data\Prototipo.mdf;Integrated Security=True";
			conn = new SqlConnection(constr);

			return true;
		}

		public SqlConnection GetConexion()
		{
			return conn;
		}

		public void Open() {
			conn.Open();
		}

		public void Close()
		{
			conn.Close();
		}
	}
}