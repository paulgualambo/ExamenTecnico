using System;
using System.Data.SqlClient;
using System.Web;

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
			string startupPath = System.IO.Directory.GetCurrentDirectory();
			//Microsoft.SqlServer.Server("~/App_Data/Prototipo.mdf");

			string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Prototipo.mdf");

			//constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pgualambo\Source\Repos\ExamenTecnico\WebApp\App_Data\Prototipo.mdf;Integrated Security=True";
			constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+path+";Integrated Security=True";
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