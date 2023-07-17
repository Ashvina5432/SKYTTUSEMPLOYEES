using Microsoft.Data.SqlClient;
using SkyEmployees.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.DAL
{
    public class EmployeeRelationRepository
    {
        string connectionString;

        public EmployeeRelationRepository()
        {
            connectionString = "Data Source=SID-PC;Initial Catalog=SkyEmployees; Integrated Security=True;encrypt=true;trustServerCertificate=true";
        }

        public List<EmployeeRelation> GetAllRelation()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<EmployeeRelation> employeeRelations = new List<EmployeeRelation>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * From EmployeeRelation";

                cmd.Connection.Open();
                var dataReader= cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    EmployeeRelation employeeRelation = new EmployeeRelation();
                    employeeRelation.Id = Guid.Parse(dataReader["id"].ToString());
                    employeeRelation.Relation = dataReader["Relation"].ToString();

                    employeeRelations.Add(employeeRelation);

                   
                   

                }
                cmd.Connection.Close();
                return employeeRelations;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if(conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public EmployeeRelation? Search(EmployeeRelation employeeRelation)
        {
            SqlConnection conn=new SqlConnection(connectionString);
            try
            {
                EmployeeRelation? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select * From EmployeeRelation";
                if (employeeRelation != null)
                {

                    if (employeeRelation.Id != null)
                    {
                        query += " WHERE Id = @Id";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Id",
                            Value = employeeRelation.Id
                        });
                    }

                    if (!string.IsNullOrEmpty(employeeRelation.Relation))
                    {
                        query += " AND Relation = @Relation";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Relation",
                            Value = employeeRelation.Relation
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
                    returnValue = new EmployeeRelation();
                    returnValue.Id = (Guid?)dataReader["Id"];
                    returnValue.Relation = dataReader["Relation"].ToString();
                   
                    break;


                }
                cmd.Connection.Close();
                return returnValue;

            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                if(conn.State !=System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
          
        }
        public Guid? AddRelation(EmployeeRelation employeeRelation)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [EmployeeRelation] (Id,Relation) values (@Id, @Relation)";

                cmd.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("Relation", SqlDbType.VarChar).Value = employeeRelation.Relation;

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

        public EmployeeRelation? UpdateRelation(Guid id,EmployeeRelation employeeRelation)
        {
            SqlConnection conn= new SqlConnection( connectionString);
            try
            {
                string query = "Update [EmployeeRelation] SET Relation=@Relation WHERE id=@id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("Relation", SqlDbType.VarChar).Value = employeeRelation.Relation;
               

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return employeeRelation;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if(conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();   
                }
            }
        }

        public bool DeleteRelation(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                int rowaffected = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from EmployeeRelation WHERE id='" + id + "'";

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
