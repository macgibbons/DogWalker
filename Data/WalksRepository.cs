using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using DogWalker.Models;

namespace DogWalker.Data
{
    public class WalksRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=LordsOfDogtown; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }
        public void addWalk(Walker walker, DateTime Date, OWNER Owner, int Duration)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    DogRepository dogRepo = new DogRepository();
                    List<Dog> allDogs = dogRepo.GetAllDogs();
                    List<Dog> ownersDogs = dogRepo.GetDogByOwner(Owner.Id);
                  
                    foreach (var d in ownersDogs)
                    {
                        cmd.CommandText = @"
                        INSERT INTO Walks (Date, Duration, WalkerId, DogId)
                        OUTPUT INSERTED.Id
                        VALUES (@Date,  @Duration, @WalkerId, @DogId)";
                        cmd.Parameters.Add(new SqlParameter("@Date", Date));
                        cmd.Parameters.Add(new SqlParameter("@Duration", Duration));
                        cmd.Parameters.Add(new SqlParameter("@WalkerId", walker.Id));
                        cmd.Parameters.Add(new SqlParameter("@DogId", d.Id));

                        int id = (int)cmd.ExecuteScalar();
                    }
                    

                    




                }
            }
        }
    }
}
