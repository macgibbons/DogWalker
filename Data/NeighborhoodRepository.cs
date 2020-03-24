using System;
using System.Collections.Generic;
using System.Text;
using DogWalker.Models;
using Microsoft.Data.SqlClient;


namespace DogWalker.Data
{
    class NeighborhoodRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=LordsOfDogtown; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Neighborhood> GetAllNeighborhoods()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Neighborhood";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Neighborhood> allNeighborhoods = new List<Neighborhood>();


                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int NameColumn = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumn);



                        var neighborhood = new Neighborhood()
                        {
                            Id = idValue,
                            Name = NameValue,
                           
                        };

                        allNeighborhoods.Add(neighborhood);
                    }

                    reader.Close();

                    return allNeighborhoods;
                }
            }
        }
    }
}
