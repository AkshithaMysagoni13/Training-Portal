using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;
using Microsoft.Data.SqlClient;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTraineeRepository : ITraineeRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOTraineeRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

       
            public void Add(Trainee trainee)
        {
            cmd.CommandText = $"INSERT INTO Trainee (TrainingId, EmpId, Status) VALUES ({trainee.TrainingId}, {trainee.EmpId}, '{trainee.Status}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        

        public void Delete(int trainingId, int empId)
        {
            cmd.CommandText = $"DELETE FROM Trainee WHERE TrainingId = {trainingId} AND EmployeeId = {empId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Trainee> GetAll()
        {
            cmd.CommandText = "SELECT * FROM Trainee";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainee> trainees = new List<Trainee>();
            while (reader.Read())
            {
                Trainee t = new Trainee
                {
                    TrainingId = (int)reader["TrainingId"],
                    EmpId = (int)reader["EmpId"],
                    Status = Convert.ToChar(reader["Status"])
                };
                trainees.Add(t);
            }

            con.Close();
            return trainees;

        }

        public Trainee GetById(int trainingId, int empId)
        {
            cmd.CommandText = $"SELECT * FROM Trainee WHERE TrainingId = {trainingId} AND EmployeeId = {empId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Trainee t = new Trainee
                {
                    TrainingId = (int)reader["TrainingId"],
                    EmpId = (int)reader["EmpId"],
                    Status = Convert.ToChar(reader["Status"])
                };
                con.Close();
                return t;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("Trainee not found.");
            }

        }

        public void Update(Trainee trainee, int trainingId, int empId)
        {
            cmd.CommandText = $"UPDATE Trainee SET Status = '{trainee.Status}' WHERE TrainingId = {trainingId} and EmployeeId = {empId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
