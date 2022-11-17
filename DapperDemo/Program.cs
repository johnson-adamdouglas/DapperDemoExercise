﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);

            var depts = repo.GetAllDepartments();

            foreach (var dept in depts)
            {
                Console.WriteLine(dept.Name);
            }
            Console.WriteLine("Enter a new department name");
            var newDept = Console.ReadLine();
            repo.InsertDepartment(newDept);
            Console.WriteLine();
            depts = repo.GetAllDepartments();
            foreach (var dept in depts)
            {
                Console.WriteLine(dept.Name);
            }

        }
    }
}