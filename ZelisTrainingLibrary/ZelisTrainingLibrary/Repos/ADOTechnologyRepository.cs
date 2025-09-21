using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTechnologyRepository : ITechnologyRepository
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTechnologyRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private int GetNextTechnologyId()
        {
            cmd.CommandText = "SELECT ISNULL(MAX(TechnologyId), 0) + 1 FROM Technology";
            con.Open();
            int nextId = (int)cmd.ExecuteScalar();
            con.Close();
            return nextId;
        }

        public void Add(Technology technology)
        {
            technology.TechnologyId = GetNextTechnologyId();

            cmd.CommandText = "INSERT INTO Technology (TechnologyId, Name, Level, Duration) " +
                              "VALUES (@Id, @Name, @Level, @Duration)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", technology.TechnologyId);
            cmd.Parameters.AddWithValue("@Name", technology.Name);
            cmd.Parameters.AddWithValue("@Level", technology.Level);
            cmd.Parameters.AddWithValue("@Duration", technology.Duration);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int technologyId)
        {
            cmd.CommandText = "DELETE FROM Technology WHERE TechnologyId = @Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", technologyId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Technology> GetAlltechnologies()
        {
            cmd.CommandText = "SELECT * FROM Technology";
            cmd.Parameters.Clear();

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Technology> techList = new List<Technology>();
            while (reader.Read())
            {
                Technology tech = new Technology
                {
                    TechnologyId = (int)reader["TechnologyId"],
                    Name = reader["Name"].ToString(), 
                    Level = Convert.ToChar(reader["Level"]),
                    Duration = (int)reader["Duration"]
                };
                techList.Add(tech);
            }

            con.Close();
            return techList;
        }

        public Technology GetById(int technologyId)
        {
            cmd.CommandText = "SELECT * FROM Technology WHERE TechnologyId = @Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", technologyId);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Technology tech = new Technology
                {
                    TechnologyId = (int)reader["TechnologyId"],
                    Name = reader["TechnologyName"].ToString(), // ✅ Fixed here
                    Level = Convert.ToChar(reader["Level"]),
                    Duration = (int)reader["Duration"]
                };
                con.Close();
                return tech;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("No such technology ID found.");
            }
        }

        public void Update(Technology technology, int technologyId)
        {
            cmd.CommandText = "UPDATE Technology SET Name = @Name, Level = @Level, Duration = @Duration WHERE TechnologyId = @Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Name", technology.Name);
            cmd.Parameters.AddWithValue("@Level", technology.Level);
            cmd.Parameters.AddWithValue("@Duration", technology.Duration);
            cmd.Parameters.AddWithValue("@Id", technologyId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
