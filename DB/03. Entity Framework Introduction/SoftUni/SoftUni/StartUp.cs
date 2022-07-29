using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetAddressesByTown(new SoftUniContext()));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employees = context.Employees.OrderBy(e => e.EmployeeId);

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} " +
                    $"{employee.JobTitle} {employee.Salary:f2}");
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50_000)
                .OrderBy(e => e.FirstName);

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} " +
                    $"from {employee.Name} - ${employee.Salary:f2}");
            }

            return stringBuilder.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address()
            { 
                AddressText = "Vitoshka 15", 
                TownId = 4,
                Employees = new List<Employee> { context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault() }
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Select(e => new { e.AddressId, e.Address.AddressText })
                .OrderByDescending(e => e.AddressId)
                .Take(10);

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.AddressText}");
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var projectsInRange = context.Projects
                .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                .ToList();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => projectsInRange.Contains(ep.Project)))
                .Select(e => new { e.FirstName, e.LastName, 
                    ManagerFirstName = e.Manager.FirstName, ManagerLastName = e.Manager.LastName,
                   Project = e.EmployeesProjects.Select(ep => new {ep.Project.Name, ep.Project.StartDate, ep.Project.EndDate})})
                .Take(10);

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: " +
                    $"{employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Project)
                {
                    if (project.EndDate != null)
                    {
                        stringBuilder.AppendLine($"--{project.Name} - " +
                            $"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - " +
                            $"{project.EndDate?.ToString("M/d/yyyy h:mm:ss tt")}");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"--{project.Name} " +
                            $"- {project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - not finished");
                    }
                }
            }

            return stringBuilder.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(at => at.AddressText)
                .Select(a => new { a.AddressText, TownName = a.Town.Name, Count = a.Employees.Count })
                .Take(10);

            foreach (var address in addresses)
            {
                stringBuilder.AppendLine($"{address.AddressText}, {address.TownName} - {address.Count} employees");               
            }

            return stringBuilder.ToString();
        }
    }
}
