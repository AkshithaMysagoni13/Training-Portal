using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainerRepository : ITrainerRepository
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTrainerRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;

        }

        public void Add(Trainer trainer)
        {
            cmd.CommandText = $"INSERT INTO Trainer VALUES ({trainer.TrainerId}, '{trainer.Name}', '{trainer.Type}', '{trainer.Email}', '{trainer.Phone}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Delete(int trainerId)
        {
            cmd.CommandText = $"DELETE FROM Trainer WHERE TrainerId = {trainerId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public List<Trainer> GetAlltrainers()
        {
            cmd.CommandText = "SELECT * FROM Trainer";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainer> trainers = new List<Trainer>();
            while (reader.Read())
            {
                Trainer trainer = new Trainer
                {
                    TrainerId = (int)reader["TrainerId"],
                    Name = reader["Name"].ToString(),
                    Type = Convert.ToChar(reader["Type"]),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
                trainers.Add(trainer);
            }

            con.Close();
            return trainers;

        }

        public Trainer GetById(int trainerId)
        {
            cmd.CommandText = $"SELECT * FROM Trainer WHERE TrainerId = {trainerId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Trainer t = new Trainer
                {
                    TrainerId = (int)reader["TrainerId"],
                    Name = reader["Name"].ToString(),
                    Type = Convert.ToChar(reader["Type"]),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
                con.Close();
                return t;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("Trainer with the given ID not found.");

            }
        }

        public void Update(Trainer trainer, int trainerId)
        {
            cmd.CommandText =
                $"UPDATE Trainer " +
                $"SET Type = '{trainer.Type}', " +
                $"Name = '{trainer.Name}', " +
                $"Email = '{trainer.Email}', " +
                $"Phone = '{trainer.Phone}' " +
                $"WHERE TrainerId = {trainerId}";

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
