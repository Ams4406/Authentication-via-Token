using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TokenAuth.Models;

namespace TokenAuth.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;
        public EmployeeRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public bool InsertEmployee(Employee OurEmployee)
        {
            int rowsAffected = this._db.Execute("INSERT Employee([Name],[Role],[RegistrationDate],[Email],[Password]) VALUES(@Name, @Role,@RegistrationDate, @Email, @Password)",
                                new { Name = OurEmployee.Name, Role = OurEmployee.Role,RegistrationDate = OurEmployee.RegistrationDate, Email = OurEmployee.Email, Password = OurEmployee.Password });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public Employee Login(string Email,string Password)
        {
            return _db.Query<Employee>("SELECT [Email],[Password] FROM [Employee] WHERE Email = @Email & Password = @Password",
                new { Email = Email, Password = Password }).FirstOrDefault();
        }

        public Employee SearchEmployeeByID(int ID)
        {
            return _db.Query<Employee>("SELECT * FROM [Employee] WHERE ID = @ID",
                new { ID = ID }).SingleOrDefault();
        }

        public Employee SearchEmployeeByName(string Name)
        {
            return _db.Query<Employee>("SELECT * FROM [Employee] WHERE Name = @Name",
                new { Name = Name }).SingleOrDefault();
        }

        public List<Employee> DisplayEmployees()
        {
            return _db.Query<Employee>("SELECT * FROM [Employee] ORDER BY ID").ToList();
        }

        public bool UpdateEmployee(Employee OurEmployee)
        {
            int rowsAffected = this._db.Execute(@"UPDATE [Employee] SET [Name] = @Name, [Role] = @Role,[RegistrationDate] = @RegistrationDate, [Email] = @Email, 
                    [Password] = @Password WHERE ID = " + OurEmployee.ID, OurEmployee);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(int ID)
        {
            int rowsAffected = this._db.Execute("DELETE FROM [Employee] WHERE ID = @ID", new { ID = ID });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}