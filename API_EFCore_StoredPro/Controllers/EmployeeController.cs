using API_EFCore_StoredPro.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_EFCore_StoredPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        DB dbopen = new DB();
        string msg = string.Empty;

        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
            emp.Type = "get";
            DataSet ds = dbopen.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    EMP_Name = dr["EMP_Name"].ToString(),
                    EMP_Email = dr["EMP_Email"].ToString(),
                }
                );

            }
            return list;
        }
        [HttpGet("{id}")]
        public List<Employee> GetID(int id)
        {
            Employee emp = new Employee();
            emp.ID = id; 
            emp.Type = "getid";
            DataSet ds = dbopen.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    EMP_Name = dr["EMP_Name"].ToString(),
                    EMP_Email = dr["EMP_Email"].ToString(),
                }
                );

            }
            return list;
        }
        [HttpPost]
        public  string Insert ([FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                
                msg = dbopen.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        [HttpPut("{id}")]
        public string Update(int id,[FromBody]Employee emp)
        {

            string msg = string.Empty;
            try
            {
                emp.ID = id;
                msg = dbopen.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Employee emp = new Employee();
                emp.ID = id;
                emp.Type = "delete";
                msg = dbopen.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
