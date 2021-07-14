using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
// using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using oap.Models;
using System.Data.SqlClient;
using System;

namespace oap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : Controller
    {

        public IConfiguration Configuration { get; }

        public ApprovalController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        [HttpGet]
        // [Route("Approvals")]
        public IEnumerable<Approval> Get()
        {
            List<Approval> approvalList = new List<Approval>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From approvals";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Approval approval = new Approval();
                        approval.Id = Convert.ToInt32(dataReader["Id"]);
                        approval.reqid = Convert.ToInt32(dataReader["reqid"]);
                        approval.level = Convert.ToString(dataReader["level"]);
                        approval.emailto = Convert.ToString(dataReader["emailto"]);
                        approval.emailcc = Convert.ToString(dataReader["emailcc"]);
                        approval.status = Convert.ToString(dataReader["status"]);
                        approval.iscompleted = Convert.ToString(dataReader["iscompleted"]);

                        approvalList.Add(approval);
                    }
                }
                connection.Close();
            }
            return approvalList;
        }

        
        // GET: api/Fruits/5
        [HttpGet("{id}")]
        public IEnumerable<Approval> GetFruit(long id)
        {
            List<Approval> approvalList = new List<Approval>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From approvals where reqid="+id;
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Approval approval = new Approval();
                        approval.Id = Convert.ToInt32(dataReader["Id"]);
                        approval.reqid = Convert.ToInt32(dataReader["reqid"]);
                        approval.level = Convert.ToString(dataReader["level"]);
                        approval.emailto = Convert.ToString(dataReader["emailto"]);
                        approval.emailcc = Convert.ToString(dataReader["emailcc"]);
                        approval.status = Convert.ToString(dataReader["status"]);
                        approval.iscompleted = Convert.ToString(dataReader["iscompleted"]);

                        approvalList.Add(approval);
                    }
                }
                connection.Close();
            }
            return approvalList;
        }
    }
}