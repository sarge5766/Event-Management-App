using EventManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace EventManagement.WebAPI.Controllers {
    public class UsersController : ApiController {
        SqlConnection conn;

        public UsersController() {
            conn = DBHelper.Conn();
        }

        [HttpPost]
        [Route("api/Users/Create")]
        public IHttpActionResult Create(User user) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Users_Insert]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/Users/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Users_Delete]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", id);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Users/GetById/{id}")]
        public IHttpActionResult GetById(int id) {
            User user = new User();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Users_GetById]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            user.UserId = Convert.ToInt32(reader["UserId"]);
                            user.Username = reader["Username"].ToString();
                            user.Password = reader["Password"].ToString();
                            user.RoleId = Convert.ToInt16(reader["RoleId"]);
                        }
                    }
                }
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/Users/GetAll")]
        public IHttpActionResult GetAll() {
            List<User> users = new List<User>();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Users_GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            users.Add(new Domain.User {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                RoleId = Convert.ToInt16(reader["RoleId"])
                            });
                        }
                    }
                }
            }

            return Ok(users);
        }

        [HttpPut]
        [Route("api/Users/Update")]
        public IHttpActionResult Put(User user) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Users_Update]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }
    }
}
