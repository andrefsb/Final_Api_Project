﻿using Application.Repository;
using Menu.Enums;
using Sharprompt;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Menu.Entities
{
    internal class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("first_name")]
        public string First_name { get; set; }
        [JsonPropertyName("last_name")]
        public string Last_name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("ip_address")]
        public string Ip_address { get; set; }

        public Employee(string first_name, string last_name, string email, string gender, string ip_address)
        {
            First_name = first_name;
            Last_name = last_name;
            Email = email;
            Gender = gender;
            Ip_address = ip_address;
        }

        public async static void AddEmployee()
        {
            HttpClient httpClient = new HttpClient();
            Console.Write("First Name: ");
            string first_name = Console.ReadLine();
            Console.Write("Last Name: ");
            string last_name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            string gender = Prompt.Select<EnumGenders>("Gender: ").ToString();
            Console.Write("Ip Adress: ");
            string ip_adress = Console.ReadLine();
            Employee employee = new Employee(first_name, last_name, email, gender, ip_adress);
            httpClient.BaseAddress = new Uri("http://localhost:5186/");
            var response = httpClient.PostAsJsonAsync("/add", employee).Result;
        }

        public static void GetEmployee()
        {
            Console.Write("Insert Employee Id: ");
            var employeeId = Console.ReadLine();
            FindEmployeeData(employeeId);
        }
        public static void FindEmployeeData(string employeeId)
        {
            try
            {
                var result = EmployeeAnalysis(employeeId).Result;
                Console.WriteLine("Employee Data:"
                        + "\nId: " + result.Id
                       + "\nFirst Name: " + result.First_name
                       + "\nLast Name: " + result.Last_name
                       + "\nEmail: " + result.Email
                       + "\nGender: " + result.Gender
                       + "\nIp Adress: " + result.Ip_address);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
        public static async Task<Employee> EmployeeAnalysis(string employeeId)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync($"http://localhost:5186/{employeeId}");
                var code = response.StatusCode;
                var message = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Employee>(message);

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw new ArgumentException(ex.Message);
            }

        }
        public static async void DeleteEmployee()

        {
            HttpClient httpClient = new HttpClient();
            Console.Write("Insert Employee Id to Delete: ");
            var employeeId = Console.ReadLine();
            FindEmployeeData(employeeId);
            var result = EmployeeAnalysis(employeeId).Result;
            Console.WriteLine($"Confirm Employee {employeeId} deletion (Y/N)?");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
            {

                httpClient.DeleteAsync("http://localhost:5186/delete/+" + employeeId);
                Console.WriteLine($"Employee {employeeId} deletion was successfull.");
            }
            else
            {
                Console.WriteLine("Deletion not successfull.");
            }

        }
        public static void ListAllEmployees()
        {
            var response = RequestAllEmployees().Result;
            foreach (var result in response)
            {
                Console.WriteLine("\nEmployee Data:"
                     + "\nId: " + result.Id
                    + "\nFirst Name: " + result.First_name
                    + "\nLast Name: " + result.Last_name
                    + "\nEmail: " + result.Email
                    + "\nGender: " + result.Gender
                    + "\nIp Adress: " + result.Ip_address); ;
            }
        }
        public static async Task<List<Employee>> RequestAllEmployees()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5186/getall");
            var message = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(message);
            return result;
        }
        public async static void EditEmployee()
        {
            Console.Write("Insert Employee Id to Edit: ");
            var employeeId = Console.ReadLine();
            FindEmployeeData(employeeId);
            var result = EmployeeAnalysis(employeeId).Result;
            HttpClient httpClient = new HttpClient();
            Console.Write("First Name");
            Console.Write($"({result.First_name}): ");
            string first_name = Console.ReadLine();
            result.First_name = string.IsNullOrWhiteSpace(first_name) ? result.First_name : first_name;
            Console.Write("Last Name");
            Console.Write($"({result.Last_name}): ");
            string last_name = Console.ReadLine();
            result.Last_name = string.IsNullOrWhiteSpace(last_name) ? result.Last_name : last_name;
            Console.Write("Email");
            Console.Write($"({result.Email}): ");
            string email = Console.ReadLine();
            result.Email = string.IsNullOrWhiteSpace(email) ? result.Email : email;
            string gender = Prompt.Select<EnumGenders>("Gender: ").ToString();
            Console.Write("Ip Adress");
            Console.Write($"({result.Ip_address}): ");
            string ip_adress = Console.ReadLine();
            result.Ip_address = string.IsNullOrWhiteSpace(ip_adress) ? result.Ip_address : ip_adress;
            Console.WriteLine($"\nConfirm Employee {employeeId} edition (Y/N)?");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "Y")
            {
                try
                {
                    var message = await httpClient.PutAsJsonAsync("http://localhost:5186/edit/" + result.Id, result);
                    if (message.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Employee {employeeId} edition was successfull.");
                    }
                    else
                    {
                        Console.WriteLine("Edition not successfull.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}


