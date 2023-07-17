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
    public class FamilyDetailsRepository
    {
        string connectionString;

        public FamilyDetailsRepository()
        {


            connectionString = "Data Source=SID-PC;Initial Catalog=SkyEmployees; Integrated Security=True;encrypt=true;trustServerCertificate=true";

        }
        public List<FamilyDetails> GetAllDetails()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<FamilyDetails> DetailsList = new List<FamilyDetails>();

            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT  ef.*,  e.FirstName as FName,er.Relation as Relation FROM   EmployeeFamilyDetails as ef INNER JOIN   Employees as e ON ef.EmployeeId = e.id INNER JOIN   EmployeeRelation as er ON ef.RelationId = er.id;";


                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    FamilyDetails emp = new FamilyDetails();
                    emp.Id = Guid.Parse(dataReader["id"].ToString());
                    emp.EmployeeId = Guid.Parse(dataReader["EmployeeId"].ToString());
                    emp.FName = dataReader["FName"].ToString();
                    emp.FirstName = dataReader["FirstName"].ToString();
                    emp.MiddleName = dataReader["MiddleName"].ToString();
                    emp.LastName = dataReader["LastName"].ToString();
                    emp.DOB = Convert.ToDateTime(dataReader["DOB"]);
                    emp.Gender = dataReader["Gender"].ToString();
                    emp.RelationId = Guid.Parse(dataReader["RelationId"].ToString());
                    emp.Relation = dataReader["Relation"].ToString();




                    DetailsList.Add(emp);


                }

                cmd.Connection.Close();
                return DetailsList;


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
        public Guid? AddFamilyDetails(FamilyDetails familyDetails)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                var id = System. Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO [EmployeeFamilyDetails] (Id, EmployeeId, FirstName, MiddleName, LastName, DOB, Gender, RelationID) VALUES (@id, @EmployeeId, @FirstName, @MiddleName, @LastName, @DOB, @Gender, @RelationId)";

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("EmployeeId", SqlDbType.UniqueIdentifier).Value = familyDetails.EmployeeId;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = familyDetails.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = familyDetails.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = familyDetails.LastName;
                cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = (DateTime)familyDetails.DOB;
                cmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = familyDetails.Gender;
                cmd.Parameters.Add("RelationId", SqlDbType.UniqueIdentifier).Value = familyDetails.RelationId;

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
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
        public FamilyDetails? Search(FamilyDetails familyDetails)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                FamilyDetails? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select * From EmployeeFamilyDetails ";

                if (familyDetails != null)
                {
                    if (familyDetails.Id != null)
                    {
                        query += " Where Id = @Id";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Id",
                            Value = familyDetails.Id
                        });

                    }


                    if (!string.IsNullOrEmpty(familyDetails.FirstName))
                    {
                        query += " Where FirstName = @FirstName";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "FirstName",
                            Value = familyDetails.FirstName
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
                    returnValue = new FamilyDetails();
                    returnValue.Id = (Guid?)dataReader["Id"];
                    returnValue.EmployeeId = (Guid)dataReader["EmployeeId"];
                    returnValue.FirstName = dataReader["FirstName"].ToString();
                    returnValue.MiddleName = dataReader["MiddleName"].ToString();
                    returnValue.LastName = dataReader["LastName"].ToString();
                    returnValue.DOB = Convert.ToDateTime(dataReader["DOB"]);
                    returnValue.Gender = dataReader["Gender"].ToString();
                    returnValue.RelationId = (Guid)dataReader["relationId"];

                    break;
                }

                cmd.Connection.Close();
                return returnValue;
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

        public FamilyDetails? UpdateFamilyDetail (Guid id,  FamilyDetails familyDetails)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "UPDATE [EmployeeFamilyDetails] SET FirstName =@FirstName,MiddleName = @MiddleName,LastName = @LastName,DOB = @DOB,Gender = @Gender WHERE Id = @id";

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = familyDetails.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = familyDetails.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = familyDetails.LastName;
                cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = familyDetails.Gender;
                

               
                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return familyDetails;


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
        public bool Delete(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                int roweffcted = 0;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE from EmployeeFamilyDetails WHERE id='" + id + "' ";

                cmd.Connection.Open();
                roweffcted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return roweffcted > 0 ? true : false;



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
