using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using DogWalker.Models;

namespace DogWalker.Data
{
   public class DogRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=LordsOfDogtown; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Dog> GetAllDogs()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT d.Id, d.[Name], d.Notes, d.OwnerId, o.Phone, o.[Address], o.Id, o.[Name] AS OwnerName
                        FROM Dog d
                        LEFT JOIN OWNER o
                        ON d.OwnerId = o.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Dog> allDogs = new List<Dog>();


                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int NameColumn = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumn);

                        int NotesColumn = reader.GetOrdinal("Notes");
                        string NotesValue = reader.GetString(NotesColumn);

                        int PhoneColumn = reader.GetOrdinal("Phone");
                        string PhoneValue = reader.GetString(PhoneColumn);

                        int AddressColumn = reader.GetOrdinal("Address");
                        string AddressValue = reader.GetString(AddressColumn);

                        int ownerIdColumn = reader.GetOrdinal("OwnerId");
                        int ownerIdValue = reader.GetInt32(ownerIdColumn);

                        int ownerNameColumn = reader.GetOrdinal("OwnerName");
                        string ownerNameValue = reader.GetString(ownerNameColumn);

                        var dog = new Dog()
                        {
                            Id = idValue,
                            Name = NameValue,
                            Notes = NotesValue,
                            
                            OwnerId = ownerIdValue,
                            Owner = new OWNER()
                            {
                                Id = ownerIdValue,
                                Name = ownerNameValue,
                                Phone = PhoneValue,
                                Address = AddressValue,
                            }
                        };

                        allDogs.Add(dog);
                    }

                    reader.Close();

                    return allDogs;
                }
            }
        }
        public Dog GetDogByOwner(int ownerId)

        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT d.Id, d.[Name], d.OwnerId, d.Notes, o.Id, o.[Name] AS OwnerName
                        FROM Dog d
                        LEFT JOIN OWNER o
                        ON d.OwnerId = o.Id
                        WHERE d.OwnerId = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", ownerId));

                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int DogNameColumn = reader.GetOrdinal("Name");
                        string DogNameValue = reader.GetString(DogNameColumn);

                        int NotesColumn = reader.GetOrdinal("Notes");
                        string NotesValue = reader.GetString(NotesColumn);

                        int OwnerIdColumn = reader.GetOrdinal("OwnerId");
                        int OwnerIdValue = reader.GetInt32(OwnerIdColumn);

                        int OwnerNameColumn = reader.GetOrdinal("OwnerName");
                        string OwnerNameValue = reader.GetString(OwnerNameColumn);

                        var dog = new Dog()
                        {
                            Id = idValue,
                            Name = DogNameValue,
                            OwnerId = OwnerIdValue,
                            Notes = NotesValue,
                            Owner = new OWNER()
                            {
                                Id = OwnerIdValue,
                                Name = OwnerNameValue
                            }
                        };


                        reader.Close();

                        return dog;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
