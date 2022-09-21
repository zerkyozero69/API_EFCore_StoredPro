using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_EFCore_StoredPro.Model
{
    public class DB
    {
        SqlConnection con = new SqlConnection("Data Source=192.168.1.8;Initial Catalog=EntityFrameworkStored;User ID=sa;Password=01012537zz");

        public string EmployeeOpt(Employee emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@EMP_Name", emp.EMP_Name);
                com.Parameters.AddWithValue("@EMP_Email", emp.EMP_Email);
                com.Parameters.AddWithValue("@Type", emp.Type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet EmployeeGet(Employee emp,out string  msg)
        {
             msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@EMP_Name", emp.EMP_Name);
                com.Parameters.AddWithValue("@EMP_Email", emp.EMP_Email);
                com.Parameters.AddWithValue("@Type", emp.Type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}
