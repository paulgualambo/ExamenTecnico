using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
	public class SucursalFacade
	{
		public List<Sucursal> List(int? IdBanco)
		{
			DBConn conn = new DBConn();

			SqlCommand cmd;
			SqlDataReader dreader;
			List<Sucursal> list = new List<Sucursal>();

			try
			{ 

				string sql, output = "";

				sql = "Select s.Id, s.Nombre, s.Direccion, s.FechaDeRegistro, s.IdBanco, b.Nombre As NombreBanco " +
					"from Sucursal s Inner join Banco b on s.IdBanco = b.Id" +
					" where IdBanco = IsNull(@IdBanco, IdBanco)";

				conn.Connect();
				conn.Open();
				cmd = new SqlCommand(sql, conn.GetConexion());

				//Parametro1
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@IdBanco";
				param1.SqlDbType = SqlDbType.Int;
				param1.IsNullable = true;
				param1.Value = !IdBanco.HasValue ? DBNull.Value : (object)IdBanco.Value;
				cmd.Parameters.Add(param1);

				dreader = cmd.ExecuteReader();


				while (dreader.Read())
				{
					output = output + dreader.GetValue(0) + " - " +
										dreader.GetValue(1) + "\n";
					Sucursal item = new Sucursal()
					{
						Id = (int)dreader.GetValue(0),
						Nombre = dreader.GetValue(1).ToString(),
						Direccion = dreader.GetValue(2).ToString(),
						FechaDeRegistro = Convert.ToDateTime(dreader.GetValue(3)),
						IdBanco = (int)dreader.GetValue(4),
						Banco = new Banco() {
							Nombre = dreader.GetValue(5).ToString(),
						}
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

		public List<Sucursal> List()
		{
			return List(null);
		}

		public void Insert(Sucursal item)
		{

			DBConn conn = new DBConn();

			SqlCommand cmd;
			SqlDataAdapter adap = new SqlDataAdapter();

			try
			{


				string sql = "";

				sql = "Insert into Sucursal (Nombre, Direccion, FechaDeRegistro, IdBanco) values(@Nombre, @Direccion, @FechaDeRegistro, @IdBanco)";

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

				//Parametro4
				SqlParameter param4 = new SqlParameter();
				param4.ParameterName = "@IdBanco";
				param4.SqlDbType = SqlDbType.Int;
				param4.Value = item.IdBanco;
				adap.InsertCommand.Parameters.Add(param4);

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