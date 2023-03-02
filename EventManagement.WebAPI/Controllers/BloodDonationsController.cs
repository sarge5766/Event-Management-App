using EventManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace EventManagement.WebAPI.Controllers {
    public class BloodDonationsController : ApiController {
        SqlConnection conn;

        public BloodDonationsController() {
            conn = DBHelper.Conn();
        }

        [HttpPost]
        [Route("api/BloodDonations/Create")]
        public IHttpActionResult Create(BloodDonation bloodDonation) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[BloodDonations_Insert]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonorId", bloodDonation.DonorId);
                    command.Parameters.AddWithValue("@Donated", bloodDonation.Donated);
                    command.Parameters.AddWithValue("@DonationDate", bloodDonation.DonationDate);
                    command.Parameters.AddWithValue("@DonationLocation", bloodDonation.DonationLocation);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/BloodDonations/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[BloodDonations_Delete]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonationId", id);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/BloodDonations/GetById/{id}")]
        public IHttpActionResult GetById(int id) {
            BloodDonation bloodDonation = new BloodDonation();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[BloodDonations_GetById]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonationId", id);

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            bloodDonation.DonationId = Convert.ToInt16(reader["DonationId"]);
                            bloodDonation.DonorId = Convert.ToInt16(reader["DonorId"]);
                            bloodDonation.Donated = Convert.ToBoolean(reader["Donated"]);
                            bloodDonation.DonationDate = Convert.ToDateTime(reader["DonationDate"]);
                            bloodDonation.DonationLocation = reader["DonationLocation"].ToString();
                        }
                    }
                }
            }

            return Ok(bloodDonation);
        }

        [HttpGet]
        [Route("api/BloodDonations/GetAll")]
        public IHttpActionResult GetAll() {
            List<BloodDonation> list = new List<BloodDonation>();

            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[BloodDonations_GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            list.Add(new BloodDonation() {
                                DonationId = Convert.ToInt16(reader["DonationId"]),
                                DonorId = Convert.ToInt16(reader["DonorId"]),
                                Donated = Convert.ToBoolean(reader["Donated"]),
                                DonationDate = Convert.ToDateTime(reader["DonationDate"]),
                                DonationLocation = reader["DonationLocation"].ToString(),
                            });

                        }
                    }
                }
            }

            return Ok(list);
        }

        [HttpPut]
        [Route("api/BloodDonations/Update")]
        public IHttpActionResult Put(BloodDonation bloodDonation) {
            using (conn) {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand()) {
                    command.CommandText = "[dbo].[BloodDonations_Update]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonationId", bloodDonation.DonationId);
                    command.Parameters.AddWithValue("@DonorId", bloodDonation.DonorId);
                    command.Parameters.AddWithValue("@Donated", bloodDonation.Donated);
                    command.Parameters.AddWithValue("@DonationDate", bloodDonation.DonationDate);
                    command.Parameters.AddWithValue("@DonationLocation", bloodDonation.DonationLocation);

                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }
    }
}