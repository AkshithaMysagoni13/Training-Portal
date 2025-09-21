using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;
using Microsoft.Data.SqlClient;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOEmployeeRepository : IEmployeeRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public ADOEmployeeRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;database=ZelisTrainingDB;integrated security=true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void DeleteEmployee(int EmployeeId)
        {
            cmd.CommandText = "DELETE FROM Employee WHERE EmpId = @Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", EmployeeId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Employee> GetAllEmployees()
        {
            cmd.CommandText = "SELECT * FROM Employee";
            cmd.Parameters.Clear();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmpId = (int)reader["EmpId"];
                emp.Name = (string)reader["Name"];
                emp.Designation = (string)reader["Designation"];
                emp.Email = (string)reader["Email"];
                emp.Phone = (string)reader["Phone"];
                employees.Add(emp);
            }
            con.Close();
            return employees;
        }

        public Employee GetEmployeeById(int eid)
        {
            cmd.CommandText = "SELECT * FROM Employee WHERE EmpId = @Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", eid);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Employee emp = new Employee();
                emp.EmpId = (int)reader["EmpId"];
                emp.Name = (string)reader["Name"];
                emp.Designation = (string)reader["Designation"];
                emp.Email = (string)reader["Email"];
                emp.Phone = (string)reader["Phone"];
                con.Close();
                return emp;
            }
            else
            {
                con.Close();
                throw new ZelisTrainingException("No such employee Id");
            }
        }

        private int GetNextEmployeeId()
        {
            cmd.CommandText = "SELECT ISNULL(MAX(EmpId), 0) + 1 FROM Employee";
            cmd.Parameters.Clear();
            con.Open();
            int nextId = (int)cmd.ExecuteScalar();
            con.Close();
            return nextId;
        }

        public void InsertEmployee(Employee employee)
        {
            employee.EmpId = GetNextEmployeeId();
            cmd.CommandText = "INSERT INTO Employee (EmpId, Name, Designation, Email, Phone) VALUES (@Id, @Name, @Desg, @Email, @Phone)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", employee.EmpId);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Desg", employee.Designation);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Phone", employee.Phone);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateEmployee(int eid, Employee employee)
        {
            cmd.CommandText = "UPDATE Employee SET Name = @Name, Designation = @Desg, Email = @Email, Phone = @Phone WHERE EmpId = @Id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Desg", employee.Designation);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Phone", employee.Phone);
            cmd.Parameters.AddWithValue("@Id", eid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

