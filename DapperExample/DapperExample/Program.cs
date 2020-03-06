using Dapper;
using Dapper.Contrib.Extensions;
using DapperExample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = ConfigurationManager.
                ConnectionStrings["DbConnection"].
                ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                //string query = "SELECT * FROM tblDoctor";
                //var doctors = con.Query<DoctorWho>(query);
                //string queryInsert = "INSERT INTO tblDoctor " +
                //    "VALUES (@DoctorNumber,@DoctorName,@BirthDate,@FirstEpisodeDate,@LastEpisodeDate)";
                //var result = con.Query<int>(queryInsert, doctors.First());
                //string queryUpdate = "UPDATE tblDoctor SET DoctorName=@Name WHERE DoctorId=@Id";
                //con.Query<int>(queryUpdate, new { name = "Semen Petrovich", Id = 7 });

                //string queryDelete = "DELETE FROM tblDoctor WHERE DoctorId=@Id";
                //con.Query<int>(queryDelete, new { id = 7 });






                //Console.WriteLine("Out doctor");
                //var doctors = con.GetAll<DoctorWho>();
                //foreach(var item in doctors)
                //{
                //    Console.WriteLine(item.DoctorName);
                //}
                //Console.WriteLine("Out all doctor");
                //var doctor = con.Get<DoctorWho>(2);
                //Console.WriteLine(doctor.DoctorName);
                //con.Insert(doctor);
                //Console.WriteLine("After insert");
                //doctors = con.GetAll<DoctorWho>();
                //foreach (var item in doctors)
                //{
                //    Console.WriteLine(item.DoctorName);
                //}
                //doctor.DoctorName = "Ivan Ivanka";
                //doctor.DoctorId = 11;            
                //con.Update(doctor);
                //con.Delete(doctor);
                bool end = false;
                while (!end)
                {
                Console.WriteLine("For exit enter 0 ");
                Console.WriteLine("Enter number page to print: ");
                int tmp= int.Parse(Console.ReadLine());


                    string query = $"SELECT  * FROM tblDoctor ORDER by tblDoctor.DoctorId OFFSET {(tmp-1)*10} ROWS FETCH NEXT 10 ROWS ONLY;";
                    var doctors = con.Query<DoctorWho>(query);

                    foreach (var item in doctors)
                    {
                        Console.WriteLine($"ID: {item.DoctorId}, Name:  {item.DoctorName}");
                    }                  
                }
            }
        }
    }
}
