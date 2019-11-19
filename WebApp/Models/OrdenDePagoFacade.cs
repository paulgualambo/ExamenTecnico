using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
	public class OrdenDePagoFacade
	{
		public List<OrdenDePago> List()
		{
			return List(null);
		}

		public List<OrdenDePago> List(string moneda)
		{
			DBConn conn = new DBConn();

			SqlCommand cmd;
			SqlDataReader dreader;
			List<OrdenDePago> list = new List<OrdenDePago>();

			try
			{


				string sql, output = "";


				sql = "Select o.Id, o.Monto, o.Moneda, o.Estado ,o.FechaDepago, o.IdSucursal, s.Nombre As NombreSucursal " +
					" from OrdenDePago o Inner join Sucursal s on o.IdSucursal = s.Id" +
					" where o.Moneda = ISNULL(@Moneda, o.Moneda)";


				conn.Connect();
				conn.Open();
				cmd = new SqlCommand(sql, conn.GetConexion());

				//Parametro1
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@Moneda";
				param1.SqlDbType = SqlDbType.NVarChar;
				param1.IsNullable = true;
				param1.Value = string.IsNullOrEmpty(moneda) ? DBNull.Value : (object)moneda;
				cmd.Parameters.Add(param1);


				dreader = cmd.ExecuteReader();


				while (dreader.Read())
				{
					output = output + dreader.GetValue(0) + " - " +
										dreader.GetValue(1) + "\n";
					OrdenDePago item = new OrdenDePago()
					{
						Id = (int)dreader.GetValue(0),
						Monto = Convert.ToDouble(dreader.GetValue(1)),
						Moneda = dreader.GetValue(2).ToString(),
						Estado = dreader.GetValue(3).ToString(),
						FechaDePago = Convert.ToDateTime(dreader.GetValue(4)),
						IdSucursal = (int)dreader.GetValue(5),
						Sucursal = new Sucursal()
						{
							Nombre = dreader.GetValue(6).ToString(),
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

		public void Insert(OrdenDePago item)
		{

			DBConn conn = new DBConn();

			SqlCommand cmd;
			SqlDataAdapter adap = new SqlDataAdapter();

			try
			{


				string sql = "";

				sql = "Insert into OrdenDePago (Monto, Moneda, Estado, FechaDePago, IdSucursal) values(@Monto, @Moneda, @Estado, @FechaDePago, @IdSucursal)";

				conn.Connect();
				conn.Open();
				adap.InsertCommand = new SqlCommand(sql, conn.GetConexion());

				//Parametro1
				SqlParameter param1 = new SqlParameter();
				param1.ParameterName = "@Monto";
				param1.SqlDbType = SqlDbType.Money;
				param1.Value = item.Monto;
				adap.InsertCommand.Parameters.Add(param1);

				//Parametro2
				SqlParameter param2 = new SqlParameter();
				param2.ParameterName = "@Moneda";
				param2.SqlDbType = SqlDbType.NVarChar;
				param2.Value = item.Moneda;
				adap.InsertCommand.Parameters.Add(param2);

				//Parametro3
				SqlParameter param3 = new SqlParameter();
				param3.ParameterName = "@Estado";
				param3.SqlDbType = SqlDbType.NVarChar;
				param3.Value = item.Estado;
				adap.InsertCommand.Parameters.Add(param3);

				//Parametro4
				SqlParameter param4 = new SqlParameter();
				param4.ParameterName = "@FechaDePago";
				param4.SqlDbType = SqlDbType.DateTime;
				param4.Value = item.FechaDePago;
				adap.InsertCommand.Parameters.Add(param4);

				//Parametro5
				SqlParameter param5 = new SqlParameter();
				param5.ParameterName = "@IdSucursal";
				param5.SqlDbType = SqlDbType.Int;
				param5.Value = item.IdSucursal;
				adap.InsertCommand.Parameters.Add(param5);

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