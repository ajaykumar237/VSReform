using Reform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Reform.DAL
{
    public class EmployeeDal
    {
        public int AddEmployee(Models.EmployeeModel e1)
        {
            string ConnectionString = "Server=localhost;Database=FormDataDb;persist security info=True;Integrated Security=SSPI;";
            string cmdText = "reEmployee";
            try
            {
                using (SqlConnection connection = new SqlConnection (ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand (cmdText, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", e1.Id);
                    cmd.Parameters.AddWithValue("@name", e1.Name);
                    cmd.Parameters.AddWithValue("@email", e1.Email);
                    cmd.Parameters.AddWithValue("@mobileNo", e1.MobileNo);
                    cmd.Parameters.AddWithValue("@salary", e1.Salary);
                    cmd.Parameters.AddWithValue("@location", e1.Location);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return 1;

        }

        public List<EmployeeDetailModel>  GetEmployee()
        {
            List < EmployeeDetailModel > res = new List<EmployeeDetailModel>();
            string ConnectionString = "Server=localhost;Database=Details;persist security info=True;Integrated Security=SSPI;";
            string cmdText = "getEmployeeDetail";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);


                    connection.Close();

                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        res.Add(new EmployeeDetailModel{
                            Employee_Name = row["Employee_Name"].ToString(),
                            Designation_Name = row["Designation_Name"].ToString(),
                            Department_Name = row["Department_Name"].ToString()
                        });
                    }
                }
                

            }
            catch (Exception ex)
            {
            }
            return res;

        }



        public List<MusicModel> GetMusic()
        {
            List<MusicModel> res = new List<MusicModel>();
            string ConnectionString = "Server=localhost;Database=Music;persist security info=True;Integrated Security=SSPI;";
            string cmdText = "SongDetail";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);


                    connection.Close();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        res.Add(new MusicModel
                        {
                            SongName = row["SongName"].ToString(),
                            WriterName = row["WriterName"].ToString(),
                            SingerName = row["SingerName"].ToString(),  
                            GenreType = row["GenreType"].ToString()

                        });
                    }
                }


            }
            catch (Exception ex)
            {
            }
            return res;

        }
    }
}
