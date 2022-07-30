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
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(new SoftUniContext()));
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
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects.Select(ep => new { ep.Project.Name, ep.Project.StartDate, ep.Project.EndDate })
                })
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

        public static string GetEmployee147(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employee = context.Employees
                .FirstOrDefault(e => e.EmployeeId == 147);

            var projects = context.EmployeesProjects
                .Where(ep => ep.EmployeeId == employee.EmployeeId)
                .Select(ep => ep.Project.Name)
                .OrderBy(p => p);

            stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            stringBuilder.AppendLine(String.Join("\n", projects));

            return stringBuilder.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    Count = d.Employees.Count,
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                });


            foreach (var department in departments)
            {
                stringBuilder.AppendLine($"{department.DepartmentName} " +
                    $"- {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return stringBuilder.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                stringBuilder.AppendLine(project.Name);
                stringBuilder.AppendLine(project.Description);
                stringBuilder.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return stringBuilder.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);


            foreach (var employee in employees)
            {
                employee.Salary = employee.Salary * 112 / 100;
            }

            employees.ToList().ForEach(e => stringBuilder
            .AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));

            return stringBuilder.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            employees.ToList().ForEach(e => stringBuilder
            .AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));

            return stringBuilder.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employeesProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeesProjects);
            context.SaveChanges();

            var employees = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .Select(ep => ep.Employee);
            context.Employees.RemoveRange(employees);
            context.SaveChanges();

            var project = context.Projects.Find(2);
            context.Projects.Remove(project);

            context.SaveChanges();

            context.Projects.Take(10).ToList().ForEach(p => stringBuilder.AppendLine(p.Name));

            return stringBuilder.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var towns = context.Towns
                .Where(t => t.Name == "Seattle");

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle");
            stringBuilder.AppendLine($"{addresses.Count()} addresses in Seattle were deleted");

            var employees = context.Employees
                .Where(e => addresses.Contains(e.Address));

            foreach (var employee in employees)
            {
                employee.AddressId = null;
                //employee.Address = null;
            }

            context.Addresses.RemoveRange(addresses);
            context.SaveChanges();

            context.Towns.RemoveRange(towns);
            context.SaveChanges();

            return stringBuilder.ToString();
        }

    }
}
