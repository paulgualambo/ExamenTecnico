using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
	public class BancoFacade
	{
		public List<Banco> List()
		{
			DBConn conn = new DBConn();

			SqlCommand cmd;
			SqlDataReader dreader;
			List<Banco> list = new List<Banco>();

			try
			{


				string sql, output = "";

				sql = "Select Id, Nombre, Direccion, FechaDeRegistro from Banco";

				conn.Connect();
				conn.Open();
				cmd = new SqlCommand(sql, conn.GetConexion());

				dreader = cmd.ExecuteReader();


				while (dreader.Read())
				{
					output = output + dreader.GetValue(0) + " - " +
										dreader.GetValue(1) + "\n";
					Banco item = new Banco()
					{
						Id = (int)dreader.GetValue(0),
						Nombre = dreader.GetValue(1).ToString(),
						Direccion = dreader.GetValue(2).ToString(),
						FechaDeRegistro = Convert.ToDateTime(dreader.GetValue(3))
					};
					list.Add(item);
				}

				// cerrando todos los objetos
				dreader.Close();
				cmd.Dispose();
				conn.Close();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return list;
		}

		public void Insert(Banco item)
		{

			DBConn conn = new DBConn();

			SqlCommand cmd;
			SqlDataAdapter adap = new SqlDataAdapter();

			try
			{


				string sql = "";

				sql = "Insert into Banco (Nombre, Direccion, FechaDeRegistro) values(@Nombre, @Direccion, @FechaDeRegistro)";

				conn.Connect();
				conn.Open();
				adap.InsertCommand = new SqlCommand(sql, conn.GetConexion());

				//Parametro1
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@Nombre";
				param1.SqlDbType = SqlDbType.NVarChar;
				param1.Value = item.Nombre;
				adap.InsertCommand.Parameters.Add(param1);

				//Parametro2
				SqlParameter param2 = new SqlParameter();
				param2.ParameterName = "@Direccion";
				param2.SqlDbType = SqlDbType.NVarChar;
				param2.Value = item.Direccion;
				adap.InsertCommand.Parameters.Add(param2);

				//Parametro3
				SqlParameter param3 = new SqlParameter();
				param3.ParameterName = "@FechaDeRegistro";
				param3.SqlDbType = SqlDbType.DateTime;
				param3.Value = item.FechaDeRegistro;
				adap.InsertCommand.Parameters.Add(param3);

				adap.InsertCommand.ExecuteNonQuery();

				adap.Dispose();
				conn.Close();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}