using EventManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.WebAPI.Controllers {
    public class ContactsController : ApiController {
        SqlConnection conn;

        public ContactsController() {
            conn = DBHelper.Conn();
        }

        [HttpPost]
        [Route("api/Contacts/Create")]
        public IHttpActionResult Create(Contact contact) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Contacts_Insert]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@MobileNumber", contact.MobileNumber);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@Zipcode", contact.Zipcode);
                    command.Parameters.AddWithValue("@BloodType", contact.BloodType);
                    command.Parameters.AddWithValue("@ReferredBy", contact.ReferredBy);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/Contacts/Delete/{id}")]
        public IHttpActionResult Put(int id) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Contacts_Delete]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContactId", id);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Contacts/GetById/{id}")]
        public IHttpActionResult GetById(int id) {
            Contact contact = new Contact();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Contacts_GetById]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContactId", id);

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            contact.ContactId = Convert.ToInt32(reader["ContactId"]);
                            contact.FirstName = reader["FirstName"].ToString();
                            contact.LastName = reader["LastName"].ToString();
                            contact.MobileNumber = reader["MobileNumber"].ToString();
                            contact.Email = reader["Email"].ToString();
                            contact.Address = reader["Address"].ToString();
                            contact.City = reader["City"].ToString();
                            contact.State = reader["State"].ToString();
                            contact.Zipcode = reader["Zipcode"].ToString();
                            contact.BloodType = (BloodType)Enum.Parse(typeof(BloodType), reader["BloodType"].ToString());
                            contact.ReferredBy = Convert.ToInt32(reader["ReferredBy"]);
                        }
                    }
                }
            }

            return Ok(contact);
        }

        [HttpGet]
        [Route("api/Contacts/GetAll")]
        public IHttpActionResult GetAll() {
            List<Contact> contacts = new List<Contact>();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Contacts_GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            contacts.Add(new Contact() {
                                ContactId = Convert.ToInt32(reader["ContactId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                MobileNumber = reader["MobileNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                Zipcode = reader["Zipcode"].ToString(),
                                BloodType = (BloodType)Enum.Parse(typeof(BloodType), reader["BloodType"].ToString()),
                                ReferredBy = Convert.ToInt32(reader["ReferredBy"])
                            });
                        }
                    }
                }
            }

            return Ok(contacts);
        }

        [HttpPut]
        [Route("api/Contacts/Update")]
        public IHttpActionResult Put(Contact contact) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[Contacts_Update]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContactId", contact.ContactId);
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@MobileNumber", contact.MobileNumber);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@Zipcode", contact.Zipcode);
                    command.Parameters.AddWithValue("@BloodType", contact.BloodType);
                    command.Parameters.AddWithValue("@ReferredBy", contact.ReferredBy);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }
    }
}