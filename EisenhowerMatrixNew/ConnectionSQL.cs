using System;
using System.Data;
//using Lib.Extensions.System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows;
namespace EisenhowerMatrixNew;

public class ConnectionSQL
{
    public void ConnectStringTest()
    {
        
    
    string connetionString = null;
    SqlConnection cnn = new SqlConnection ();
    connetionString = "Server= localhost; Database= EisenhowerMatrix; Integrated Security=SSPI;";
    cnn = new SqlConnection(connetionString);
        try
        {
            cnn.Open();
            Console.WriteLine("udany");
            
            // MessageBox.Show("Connection Open ! ");
            // MessageBox.Show("karol");
            
            cnn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("nieudany");
            // MessageBox.Show("Can not open connection ! ");
        }

    }

    public void ReadTasks()
    {
        
    }
    // public void SQLConnection(string query)
    // {
    //
    //     string connetionString = null;
    //     SqlConnection cnn = new SqlConnection ();
    //     connetionString = 
    //     cnn = new SqlConnection(connetionString);
    //     try
    //     {
    //         cnn.Open();
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("nieudany");
    //         // MessageBox.Show("Can not open connection ! ");
    //     }
    // }
    public static string CreateCommand(string queryString)
    {
        string connectionString = ConnectionString();
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            //command.ExecuteReader();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string test = reader.ToString();
                    return test;
                }
                
            }

            return "klarol";

        }
    }

    private static string ConnectionString()
    {
        return "Server= localhost; Database= EisenhowerMatrix; Integrated Security=SSPI;";
    }
    
    public static DataSet SelectRows(DataSet dataset,string queryString)
    {
        string connectionString = ConnectionString();
        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                queryString, connection);
            adapter.Fill(dataset);
            return dataset;
        }
    }
}