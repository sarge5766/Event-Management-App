using EventManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace EventManagement.WebAPI.Controllers {
    public class RolesController : ApiController {
        SqlConnection conn;

        public RolesController() {
            conn = DBHelper.Conn();
        }

        [HttpPost]
        [Route("api/Roles/Create")]
        public IHttpActionResult Create(Role role) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Roles_Insert]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", role.RoleName);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/Roles/Delete/{id}")]
        public IHttpActionResult Put(int id) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Roles_Delete]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleId", id);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Roles/GetById/{id}")]
        public IHttpActionResult GetById(int id) {
            Role role = new Role();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Roles_GetById]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleId", id);

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            role.RoleId = Convert.ToInt32(reader["RoleId"]);
                            role.RoleName = reader["RoleName"].ToString();
                        }
                    }
                }
            }

            return Ok(role);
        }

        [HttpGet]
        [Route("api/Roles/GetAll")]
        public IHttpActionResult GetAll() {
            List<Role> roles = new List<Role>();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Roles_GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            roles.Add(new Role {
                                RoleId = Convert.ToInt32(reader["RoleId"]),
                                RoleName = reader["RoleName"].ToString()
                            });
                        }
                    }
                }
            }

            return Ok(roles);
        }

        [HttpPut]
        [Route("api/Roles/Update")]
        public IHttpActionResult Put(Role role) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Roles_Update]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleId", role.RoleId);
                    command.Parameters.AddWithValue("@RoleName", role.RoleName);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }
    }
}
