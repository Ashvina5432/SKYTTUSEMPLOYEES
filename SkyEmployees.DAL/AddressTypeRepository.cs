using Microsoft.Data.SqlClient;
using SkyEmployees.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.DAL
{
    public class AddressTypeRepository
    {
        string connectionString;

        public AddressTypeRepository()
        {
            connectionString = "Data Source=SID-PC;Initial Catalog=SkyEmployees; Integrated Security=True;encrypt=true;trustServerCertificate=true";
        }

        public List<AddressTypes> GetAllAddressType()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<AddressTypes> AddressType = new List<AddressTypes>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * From AddressType";

                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    AddressTypes addresstype = new AddressTypes();
                    addresstype.Id = Guid.Parse(dataReader["id"].ToString());
                    addresstype.AddressType = dataReader["AddressType"].ToString();

                    AddressType.Add(addresstype);




                }
                cmd.Connection.Close();
                return AddressType;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public AddressTypes? Search(AddressTypes addressTypes)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                AddressTypes? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select * From AddressType";
                if (addressTypes != null)
                {

                    if (addressTypes.Id != null)
                    {
                        query += " WHERE Id = @Id";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Id",
                            Value = addressTypes.Id
                        });
                    }

                    if (!string.IsNullOrEmpty(addressTypes.AddressType))
                    {
                        query += " AND AddressType = @AddressType";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "AddressType",
                            Value = addressTypes.AddressType
                        });
                    }

                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    returnValue = new AddressTypes();
                    returnValue.Id = (Guid?)dataReader["Id"];
                    returnValue.AddressType = dataReader["AddressType"].ToString();

                    break;


                }
                cmd.Connection.Close();
                return returnValue;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

        }
        public Guid? AddAddressType(AddressTypes addressTypes)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [AddressType] (Id,AddressType) values (@Id, @AddressType)";

                cmd.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("AddressType", SqlDbType.VarChar).Value = addressTypes.AddressType;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (result > 0)
                    return id;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed) ;
                {
                    conn.Close();
                }
            }

        }

        public AddressTypes? UpdateAddressType(Guid id,AddressTypes addressTypes)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string query = "Update [AddressType] SET AddressType=@AddressType WHERE id=@id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("AddressType", SqlDbType.VarChar).Value =addressTypes.AddressType ;


                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return addressTypes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteAddressType(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                int rowaffected = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from AddressType WHERE id='" + id + "'";

                cmd.Connection.Open();
                rowaffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return rowaffected > 0 ? true : false;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
