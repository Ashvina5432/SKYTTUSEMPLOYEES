using Microsoft.Data.SqlClient;
using SkyEmployees.Core;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SkyEmployees.DAL
{
    public class EmployeeRepository
    {
        string connectionString;
        public EmployeeRepository()
        {
            connectionString = "Data Source=SID-PC;Initial Catalog=SkyEmployees; Integrated Security=True;encrypt=true;trustServerCertificate=true" ;
        }
        // Get All Employee

        public List<Employee> GetAllEmployee()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<Employee> employeeList = new List<Employee>();

            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select* from Employees";

                cmd.Connection.Open();
                var dataReader= cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Guid.Parse(dataReader["id"].ToString());
                    emp.EmpCode = dataReader["EmpCode"].ToString();
                    emp.FirstName= dataReader["FirstName"].ToString();
                    emp.MiddleName = dataReader["MiddleName"].ToString();
                    emp.LastName = dataReader["LastName"].ToString();
                    emp.Email = dataReader["Email"].ToString();
                    emp.DOJ= Convert.ToDateTime(dataReader["DOJ"]);
                    emp.DOB = Convert.ToDateTime (dataReader["DOB"]);
                    emp.Gender = dataReader["Gender"].ToString();
                    emp.Designation = dataReader["Designation"].ToString();
                    emp.Phone = dataReader["Phone"].ToString();
                    emp.Mobile = dataReader["Mobile"].ToString();
                    emp.EmergencyContactNo = dataReader["EmergencyContactNo"].ToString();
                    emp.EmergencyContactName = dataReader["EmergencyContactName"].ToString();


                    employeeList.Add(emp);

                    
                }

                cmd.Connection.Close();
                return employeeList;
                    

            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                if (conn.State !=  System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        // Get Employee 

        public Employee? Search(Employee employee)
        {
           SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                Employee? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select * From Employees ";

                if (employee != null)
                {
                    if(employee.Id != null)
                    {
                        query += " Where Id = @Id";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Id",
                            Value = employee.Id
                        });

                    }


                    if(!string.IsNullOrEmpty(employee.FirstName))
                    {
                        query += " Where FirstName = @FirstName";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "FirstName",
                            Value = employee.FirstName
                        });
                    }
                    if(!string.IsNullOrEmpty(employee.EmpCode))
                    {
                        query += " where EmpCode = @EmpCode";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "EmpCode",
                            Value = employee.EmpCode
                        });
                    }




             
                }
                


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query ;

                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open();
                var dataReader=cmd.ExecuteReader();
                 while (dataReader.Read())
                {
                    returnValue = new Employee();
                    returnValue.Id = (Guid?)dataReader["Id"];
                    returnValue.EmpCode = dataReader["EmpCode"].ToString();
                    returnValue.FirstName = dataReader["FirstName"].ToString();
                    returnValue.MiddleName = dataReader["MiddleName"].ToString();
                    returnValue.LastName = dataReader["LastName"].ToString();
                    returnValue.Email = dataReader["Email"].ToString();
                    returnValue.DOJ = Convert.ToDateTime(dataReader["DOJ"]);
                    returnValue.DOB = Convert.ToDateTime(dataReader["DOB"]);
                    returnValue.Gender = dataReader["Gender"].ToString();
                    returnValue.Designation = dataReader["Designation"].ToString();
                    returnValue.Phone = dataReader["Phone"].ToString();
                    returnValue.Mobile = dataReader["Mobile"].ToString();
                    returnValue.EmergencyContactNo = dataReader["EmergencyContactNo"].ToString();
                    returnValue.EmergencyContactName = dataReader["EmergencyContactName"].ToString();


                    break;
                }

                cmd.Connection.Close();
                return returnValue;
            }catch (Exception )
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

        // Add Employee
         public Guid? AddEmployee(Employee employee)
        {
            SqlConnection conn=  new SqlConnection(connectionString);
            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= conn;
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [employees](id,EmpCode,FirstName,MiddleName,LastName,Email,DOJ,DOB,Gender,Designation,Phone,Mobile,EmergencyContactNo,EmergencyContactName)values(@id,@EmpCode,@FirstName,@MiddleName,@LastName,@Email,@DOJ,@DOB,@Gender,@Designation,@Phone,@Mobile,@EmergencyContactNo,@EmergencyContactName)";

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value =id;
                cmd.Parameters.Add("EmpCode", SqlDbType.VarChar).Value = employee.EmpCode;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = employee.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = employee.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = employee.LastName;
                cmd.Parameters.Add("Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("DOJ", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("DOB", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = employee.Gender;
                cmd.Parameters.Add("Designation", SqlDbType.VarChar).Value = employee.Designation;
                cmd.Parameters.Add("Phone", SqlDbType.VarChar).Value = employee.Phone;
                cmd.Parameters.Add("Mobile", SqlDbType.VarChar).Value = employee.Mobile;
                cmd.Parameters.Add("EmergencyContactNo", SqlDbType.VarChar).Value = employee.EmergencyContactNo;
                cmd.Parameters.Add("EmergencyContactName", SqlDbType.VarChar).Value = employee.EmergencyContactName;



                cmd.Connection.Open();
                var result= cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (result > 0)
                    return id;
                else
                    return null;



            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                if(conn.State != ConnectionState.Closed) 
                {
                    conn.Close();
                }
            }
        }
        // Update Employee

        public Employee Update(Guid id,Employee employee)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "UPDATE Employees SET [EmpCode]=@EmpCode,[FirstName]=@FirstName,[MiddleName]=@MiddleName,[LastName]=@LastName,[Email]=@Email,[DOJ]=@DOJ,[DOB]=@DOB," +
                    "[Gender]=@Gender,[Designation]=@Designation,[Phone]=@Phone,[Mobile]=@Mobile,[EmergencyContactNo]=@EmergencyContactNo," +
                    "[EmergencyContactName]=@EmergencyContactName WHERE [Id] = @id";

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("EmpCode", SqlDbType.VarChar).Value = employee.EmpCode;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = employee.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = employee.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = employee.LastName;
                cmd.Parameters.Add("Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("DOJ", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = employee.Gender;
                cmd.Parameters.Add("Designation", SqlDbType.VarChar).Value = employee.Designation;
                cmd.Parameters.Add("Phone", SqlDbType.VarChar).Value = employee.Phone;
                cmd.Parameters.Add("Mobile", SqlDbType.VarChar).Value = employee.Mobile;
                cmd.Parameters.Add("EmergencyContactNo", SqlDbType.VarChar).Value = employee.EmergencyContactNo;
                cmd.Parameters.Add("EmergencyContactName",SqlDbType.VarChar).Value= employee.EmergencyContactName;

                cmd.Connection.Open();
               var  result =cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return employee;


            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(conn.State != ConnectionState.Closed)

                {
                    conn.Close(); 
                }
            }
           

        }
        // Delete Employee

        public bool Delete(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                int roweffcted = 0;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE from Employees WHERE id='"+id+"' ";

                cmd.Connection.Open ();
                roweffcted=cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return roweffcted > 0 ?true :false;


                
            }
            catch (Exception )
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


        // Check for Email Existance
        public bool CheckEmailExistance(string email)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select Email from [Employees] Where Email= '" + email + "'";
            var returnValue = false;

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                returnValue = true;
            }

            return returnValue;

        }
    }
    
}