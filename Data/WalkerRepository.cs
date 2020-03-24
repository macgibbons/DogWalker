using System;
using System.Collections.Generic;
using System.Text;
using DogWalker.Models;
using Microsoft.Data.SqlClient;

namespace DogWalker.Data
{
    public class WalkerRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=LordsOfDogtown; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Walker> GetAllWalkers()
        {
            
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, w.Name, w.NeighborhoodId, n.Id, n.Name AS NeighborhoodName
                        FROM Walker w
                        LEFT JOIN Neighborhood n
                        ON w.NeighborhoodId = n.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walker> allWalkers = new List<Walker>();


                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int NameColumn = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumn);

                      

                        int neighborhoodIdColumn = reader.GetOrdinal("NeighborhoodId");
                        int neighborhoodValue = reader.GetInt32(neighborhoodIdColumn);

                        int neighborhoodNameColumn = reader.GetOrdinal("NeighborhoodName");
                        string neighborhoodNameValue = reader.GetString(neighborhoodNameColumn);

                        var walker = new  Walker()
                        {
                            Id = idValue,
                            Name = NameValue,
                            NeighborhoodId = neighborhoodValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = neighborhoodValue,
                                Name = neighborhoodNameValue
                            }
                        };

                        allWalkers.Add(walker);
                    }

                    reader.Close();

                    return allWalkers;
                }
            }
        }

       
        public Walker GetWalkerByNeighborhood(int neighborhoodId)

        {
          
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, w.Name, w.NeighborhoodId, n.Id, n.Name AS NeighborhoodName
                        FROM Walker w
                        LEFT JOIN Neighborhood n
                        ON w.NeighborhoodId = n.Id
                        WHERE w.NeighborhoodId = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", neighborhoodId));

                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int WalkerNameColumn = reader.GetOrdinal("Name");
                        string WalkerNameValue = reader.GetString(WalkerNameColumn);

                        int neighborhoodIdColumn = reader.GetOrdinal("NeighborhoodId");
                        int neighborhoodIdValue = reader.GetInt32(neighborhoodIdColumn);

                        int neighborhoodNameColumn = reader.GetOrdinal("NeighborhoodName");
                        string neighborhoodNameValue = reader.GetString(neighborhoodNameColumn);

                        var walker = new Walker()
                        {
                            Id = idValue,
                            Name = WalkerNameValue,
                            NeighborhoodId = neighborhoodIdValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = neighborhoodIdValue,
                                Name = neighborhoodNameValue
                            }
                        };


                        reader.Close();

                        return walker;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        //Query the database for all the Walkers.
    }
}
