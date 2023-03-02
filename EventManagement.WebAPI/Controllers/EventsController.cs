using EventManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace EventManagement.WebAPI.Controllers {
    public class EventsController : ApiController {
        SqlConnection conn;

        public EventsController() {
            conn = DBHelper.Conn();
        }

        [HttpPost]
        [Route("api/Events/Create")]
        public IHttpActionResult Create(Event e) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Events_Insert]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", e.Name);
                    command.Parameters.AddWithValue("@EventDate", e.EventDate);
                    command.Parameters.AddWithValue("@IsActive", e.IsActive);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/Events/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Events_Delete]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EventId", id);
                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Events/GetById/{id}")]
        public IHttpActionResult GetById(int id) {
            Event e = new Event();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Events_GetById]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EventId", id);

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            e.EventId = Convert.ToInt32(reader["EventId"]);
                            e.Name = reader["Name"].ToString();
                            e.EventDate = Convert.ToDateTime(reader["EventDate"]);
                        }
                    }
                }

                return Ok(e);
            }
        }

        [HttpGet]
        [Route("api/Events/GetAll")]
        public IHttpActionResult GetAll() {
            List<Event> events = new List<Event>();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Events_GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            events.Add(new Event {
                                EventId = Convert.ToInt32(reader["EventId"]),
                                Name = reader["Name"].ToString(),
                                EventDate = Convert.ToDateTime(reader["EventDate"])
                            });
                        }
                    }
                }
            }

            return Ok(events);
        }

        [HttpPut]
        [Route("api/Events/Update")]
        public IHttpActionResult Put(Event e) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Events_Update]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EventId", e.EventId);
                    command.Parameters.AddWithValue("@Name", e.Name);
                    command.Parameters.AddWithValue("@EventDate", e.EventDate);
                    command.Parameters.AddWithValue("@IsActive", e.IsActive);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }
    }
}