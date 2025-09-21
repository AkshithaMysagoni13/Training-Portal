using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainingRepository : ITrainingRepository
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTrainingRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private int GetNextTrainingId()
        {
            cmd.CommandText = "SELECT ISNULL(MAX(TrainingId), 0) + 1 FROM Training";
            con.Open();
            int nextId = (int)cmd.ExecuteScalar();
            con.Close();
            return nextId;
        }

        public void Add(Training training)
        {
           
            training.TrainingId = GetNextTrainingId();

            cmd.CommandText = $"INSERT INTO Training VALUES ({training.TrainingId}, {training.TrainerId}, {training.TechnologyId}, '{training.StartDate:yyyy-MM-dd}', '{training.EndDate:yyyy-MM-dd}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int trainingId)
        {
            cmd.CommandText = $"DELETE FROM Training WHERE TrainingId = {trainingId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public List<Training> GetAlltrainings()
        {
            cmd.CommandText = "SELECT * FROM Training";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Training> trainingList = new List<Training>();
            while (reader.Read())
            {
                Training training = new Training
                {
                    TrainingId = (int)reader["TrainingId"],
                    TrainerId = (int)reader["TrainerId"],
                    TechnologyId = (int)reader["TechnologyId"],
                    StartDate = (DateTime)reader["StartDate"],
                    EndDate = (DateTime)reader["EndDate"]
                };
                trainingList.Add(training);
            }

            con.Close();
            return trainingList;

        }

        public Training GetById(int trainingId)
        {
            cmd.CommandText = $"SELECT * FROM Training WHERE TrainingId = {trainingId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Training training = new Training
                {
                    TrainingId = (int)reader["TrainingId"],
                    TrainerId = (int)reader["TrainerId"],
                    TechnologyId = (int)reader["TechnologyId"],
                    StartDate = (DateTime)reader["StartDate"],
                    EndDate = (DateTime)reader["EndDate"]
                };
                con.Close();
                return training;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("Training with the given ID not found.");
            }

        }

        public void Update(Training training, int trainingId)
        {
            cmd.CommandText = $"update Training set TrainerId = {training.TrainerId}, TechnologyId = {training.TechnologyId}, StartDate = '{training.StartDate:yyyy-MM-dd}', EndDate = '{training.EndDate:yyyy-MM-dd}' where TrainingId = {trainingId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
