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
    public class EmployeeAddressRepository
    {
        string connectionString;

        public EmployeeAddressRepository()
        {
            connectionString = "Data Source=SID-PC;Initial Catalog=SkyEmployees; Integrated Security=True;encrypt=true;trustServerCertificate=true"; 
        }
        public List<EmployeeAddress> GetAllAddress()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<EmployeeAddress> empAddresses = new List<EmployeeAddress>();

            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.CommandText = "SELECT EmpAddress.*, Employees.FirstName as FirstName, AddressType.AddressType as AddressType FROM EmpAddress INNER JOIN Employees ON EmpAddress.EmployeeId = Employees.Id INNER JOIN AddressType ON EmpAddress.AddressTypeId = AddressType.Id; ";
               
                cmd.Connection.Open();
                var dataReader= cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    EmployeeAddress empAddress = new EmployeeAddress();
                    empAddress.Id = Guid.Parse(dataReader["id"].ToString());
                    empAddress.Address = dataReader["Address"].ToString();
                    empAddress.AddressTypeId = Guid.Parse(dataReader["AddressTypeId"].ToString());
                    empAddress.EmployeeId = Guid.Parse(dataReader["EmployeeId"].ToString());
                    empAddress.FirstName = dataReader["FirstName"].ToString();
                    empAddress.AddressType = dataReader["AddressType"].ToString();

                    empAddress.City= dataReader["City"].ToString() ;
                    empAddress.State = dataReader["State"].ToString();
                    empAddress.Country = dataReader["Country"].ToString();
                    empAddress.PinCode = dataReader["PinCode"].ToString();

                    empAddresses.Add(empAddress);

                }
                cmd.Connection.Close();
                return empAddresses;
                


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if(conn.State != ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public EmployeeAddress? Search(EmployeeAddress empaddress)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try{

                EmployeeAddress? returnValue= null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select * From EmpAddress";
                if(empaddress != null)
                {

                    if(empaddress.Id != null)
{
                        query += " WHERE Id = @Id";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Id",
                            Value = empaddress.Id
                        });
                    }

                    

                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType= System.Data.CommandType.Text;  
                cmd.CommandText= query;
                foreach(SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                cmd.Connection.Open();
                var dataReader= cmd.ExecuteReader();
                while(dataReader.Read() )
                {
                    returnValue=new EmployeeAddress();
                    returnValue.Id = (Guid?)dataReader["Id"];
                    returnValue.Address = dataReader["Address"].ToString();
                    returnValue.AddressTypeId = (Guid?)dataReader["AddressTypeId"];
                    returnValue.EmployeeId = (Guid?)dataReader["EmployeeId"];
                    returnValue.City = dataReader["City"].ToString();
                    returnValue.State = dataReader["State"].ToString();
                    returnValue.Country = dataReader["Country"].ToString();
                    returnValue.PinCode = dataReader["PinCode"].ToString();
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
                if(conn.State != ConnectionState.Open) 
                { 
                    
                    conn.Close(); 
                }

            }
        }
        public Guid? AddAddress(EmployeeAddress empaddress) 
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                var id = Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                 cmd.CommandText = "Insert Into [EmpAddress](id,Address,AddressTypeId,EmployeeId,City,State,Country,PinCode)values(@id,@Address,@AddressTypeId,@EmployeeId,@City,@State,@Country,@PinCode)";

                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("Address", SqlDbType.VarChar).Value = empaddress.Address;
                cmd.Parameters.Add("AddressTypeId", SqlDbType.UniqueIdentifier).Value = empaddress.AddressTypeId;
                cmd.Parameters.Add("EmployeeId", SqlDbType.UniqueIdentifier).Value = empaddress.EmployeeId;
                cmd.Parameters.Add("City",SqlDbType.VarChar).Value = empaddress.City;
                cmd.Parameters.Add("State",SqlDbType.VarChar).Value= empaddress.State;
                cmd.Parameters.Add("Country",SqlDbType.VarChar).Value=empaddress.Country;
                cmd.Parameters.Add("PinCode",SqlDbType.VarChar).Value=empaddress.PinCode;


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

        public EmployeeAddress? UpdateAddress(Guid id, EmployeeAddress empaddress)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string query = "Update [EmpAddress] SET Address=@Address,City=@City,State=@State,Country=@Country,Pincode=@Pincode WHERE id=@id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.CommandText= query;

                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("Address",SqlDbType.VarChar).Value= empaddress.Address;
              
  
                cmd.Parameters.Add("City", SqlDbType.VarChar).Value = empaddress.City;
                cmd.Parameters.Add("State",SqlDbType.VarChar).Value = empaddress.State;
                cmd.Parameters.Add("Country", SqlDbType.VarChar).Value = empaddress.Country;
                cmd.Parameters.Add("PinCode", SqlDbType.VarChar).Value = empaddress.PinCode;

                cmd.Connection.Open();
                var result =cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return empaddress;

            }
            catch(Exception ex)
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

        public bool DeleteAddress(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                int rowaffected = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from EmpAddress WHERE id='" + id + "'";

                cmd.Connection.Open();

                rowaffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return rowaffected > 0 ? true : false;
       

            }
            catch(Exception)
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
    }
}
