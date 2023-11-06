using System.Data.SqlClient;

namespace sql_connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetData(1);
            GetAllDatas();
            //Insert();
            Delete(8);
            Update("Orxan",12);
        }

        static void GetData(int id)
        {
            string connect = "Server=MSI;Database=Task;Trusted_Connection=True;";
            using (SqlConnection sqlConnection1 = new SqlConnection(connect))
            {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Name FROM Students WHERE ID = {id}", sqlConnection1);
                string a = (string)cmd.ExecuteScalar();
                Console.WriteLine(a);


            }
        }

        static void GetAllDatas()
        {
            string connect = "Server=MSI;Database=Task;Trusted_Connection=True;";
            using (SqlConnection sqlConnection1 = new SqlConnection(connect))
            {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Students", sqlConnection1);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4] + " " + reader[5]);
                    }
                }


            }
        }
        static void Insert()
        {
            string connect = "Server=MSI;Database=Task;Trusted_Connection=True;";
            using (SqlConnection sqlConnection1 = new SqlConnection(connect))
            {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Students VALUES ('Israfil','Zohrabov',30,'true',1) ", sqlConnection1);
                int check = cmd.ExecuteNonQuery();
                if(check > 0)
                {
                    Console.WriteLine("INSERTED");

                }
                else
                {
                    Console.WriteLine("ERROR !!!");
                }


            }
        }
        static void Delete(int id)
        {
            string connect = "Server=MSI;Database=Task;Trusted_Connection=True;";
            using (SqlConnection sqlConnection1 = new SqlConnection(connect))
            {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Students WHERE ID = {id}", sqlConnection1);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    Console.WriteLine($"DELETED");

                }
                else
                {
                    Console.WriteLine("ERROR !!!");
                }


            }
        }
        static void Update(string name,int id)
        {
            string connect = "Server=MSI;Database=Task;Trusted_Connection=True;";
            using (SqlConnection sqlConnection1 = new SqlConnection(connect))
            {
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Students SET Name = '{name}' WHERE ID = {id}", sqlConnection1);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    Console.WriteLine($"UPTADED");

                }
                else
                {
                    Console.WriteLine("ERROR !!!");
                }


            }
        }






    }
}