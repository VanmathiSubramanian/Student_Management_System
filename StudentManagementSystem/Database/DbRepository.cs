using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Database
{
    public class DbRepository
    {
        private const string connectionString = @"Data Source=DESKTOP-MHPPEU4\SQLEXPRESS;
            Trusted_Connection=true;
            Initial Catalog=Student_Management_System;
            Connection timeout=60";

        // SqlConnection object
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static void InsertData(string insertSql)
        {
            using (SqlConnection connectionString = GetConnection())
            {
                if (connectionString == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", connectionString.State.ToString());
                    return;
                }

                try
                {
                    SqlCommand cmd = new SqlCommand(insertSql, connectionString);
                    connectionString.Open();
                    cmd.ExecuteNonQuery();
                    connectionString.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(insertSql);
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (connectionString != null)
                    {
                        connectionString.Close();
                    }
                }
            }

        }

        public static DataSet ReadData(string sqlQuery)
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if (myConnection == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", myConnection.State.ToString());
                    throw new InvalidOperationException("Cannot connect to the database");
                }

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sqlQuery, myConnection);
                    DataSet ds = new DataSet();
                    myConnection.Open();
                    da.Fill(ds);
                    myConnection.Close();
                    return ds;

                }
                catch (Exception e)
                {
                    Console.WriteLine(sqlQuery);
                    Console.WriteLine(e.Message);
                    throw new InvalidOperationException(e.Message);
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }
                }

            }
        }
    }
}
