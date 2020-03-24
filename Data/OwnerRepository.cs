using System;
using System.Collections.Generic;
using System.Text;
using DogWalker.Models;
using Microsoft.Data.SqlClient;


namespace DogWalker.Data
{
    public class OwnerRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=LordsOfDogtown; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }
        //Query the database for all the Walkers.
        public List<OWNER> GetAlOwners()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT o.Id, o.[Name], o.NeighborhoodId, o.Phone, o.[Address], n.Id, n.[Name] AS NeighborhoodName
                        FROM [OWNER] o
                        LEFT JOIN Neighborhood n
                        ON o.NeighborhoodId = n.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<OWNER> allOwners = new List<OWNER>();


                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int NameColumn = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumn);

                        int PhoneColumn = reader.GetOrdinal("Phone");
                        string PhoneValue = reader.GetString(PhoneColumn);

                        int AddressColumn = reader.GetOrdinal("Address");
                        string AddressValue = reader.GetString(AddressColumn);

                        int neighborhoodIdColumn = reader.GetOrdinal("NeighborhoodId");
                        int neighborhoodValue = reader.GetInt32(neighborhoodIdColumn);

                        int neighborhoodNameColumn = reader.GetOrdinal("NeighborhoodName");
                        string neighborhoodNameValue = reader.GetString(neighborhoodNameColumn);

                        var owner = new OWNER()
                        {
                            Id = idValue,
                            Name = NameValue,
                            Phone = PhoneValue,
                            Address = AddressValue,
                            NeighborhoodId = neighborhoodValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = neighborhoodValue,
                                Name = neighborhoodNameValue
                            }
                        };

                        allOwners.Add(owner);
                    }

                    reader.Close();

                    return allOwners;
                }
            }
        }

        public void AddOwner(OWNER owner)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO OWNER (Name, Phone, Address, NeighborhoodId)
                        OUTPUT INSERTED.Id
                        VALUES (@Name, @Phone, @Address,  @NeighborhoodId)";
                    cmd.Parameters.Add(new SqlParameter("@Name", owner.Name));
                    cmd.Parameters.Add(new SqlParameter("@Phone", owner.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Address", owner.Address));
                    cmd.Parameters.Add(new SqlParameter("@NeighborhoodId", owner.NeighborhoodId));

                    int id = (int)cmd.ExecuteScalar();

                    owner.Id = id;




                }
            }
        }
    }
}
