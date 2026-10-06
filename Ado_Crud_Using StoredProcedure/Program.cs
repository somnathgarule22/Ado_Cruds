using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ado_Crud_Using_StoredProcedure
{
    internal class Program
    {
        string connectionstring = @"Data Source=DESKTOP-SL2CECN;Initial Catalog=practicetaskdb;Integrated Security=True";
        
        public void AddEmployee()
        {
            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Employee Designation");
            string des = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary");
            float sal = (float)Convert.ToDouble(Console.ReadLine());


            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                 con.Open();
                SqlCommand cmd = new SqlCommand("sp_employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "Insert");
                cmd.Parameters.AddWithValue("@id", 0);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@designation", des);
                cmd.Parameters.AddWithValue("@salary", sal);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    Console.WriteLine("Employee Added Successfully");
                }
                else
                {
                    Console.WriteLine("Error!!Please Try Again");
                }




            }

        }

        public void UpdateEmployee()
        {
            Console.WriteLine("Enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Employee Designation");
            string des = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary");
            string sal = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "Update");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@designation", des);
                cmd.Parameters.AddWithValue("salary", sal);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    Console.WriteLine("Employee Updated successfully");

                }
                else
                {
                    Console.WriteLine("Error!! Please Try Again");
                }


            }
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            using(SqlConnection con=new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "Delete");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", "");
                cmd.Parameters.AddWithValue("@designation", "");
                cmd.Parameters.AddWithValue("salary", 0);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    Console.WriteLine("Employee Deleted successfully");

                }
                else
                {
                    Console.WriteLine("Error!! Please Try Again");
                }
            }
        }
        public void FetchAllEmployee()
        {
            using(SqlConnection con=new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_FetchEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    int id= Convert.ToInt32(dr["ID"]);
                    string name = dr["Employee_Name"].ToString();
                    string des = dr["designation"].ToString();
                    float sal = (float)Convert.ToDouble(dr["Salary"].ToString());
                    Console.WriteLine(id+" "+name+" "+des+" "+sal);

                }
            }
        }
        public void FetchEmployeeById()
        {
            Console.WriteLine("Enter Employee ID");
            int id = Convert.ToInt32(Console.ReadLine());

            using(SqlConnection con=new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_FetchEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr=cmd.ExecuteReader();
                if(dr.Read())
                {
                    int eid = Convert.ToInt32(dr["ID"]);
                    string name = dr["Employee_Name"].ToString();
                    string des = dr["designation"].ToString();
                    float sal = (float)Convert.ToDouble(dr["Salary"].ToString());
                    Console.WriteLine(eid + " " + name + " " + des + " " + sal);
                }
            }
        }
            
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.AddEmployee();
            //p.UpdateEmployee();
            // p.DeleteEmployee();
            p.FetchEmployeeById();
           // p.FetchAllEmployee();
            Console.ReadLine();
        }
    }
}
