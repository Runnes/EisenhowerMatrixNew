using System;
using System.Data;
//using Lib.Extensions.System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Documents;

namespace EisenhowerMatrixNew;

public class ConnectionSQL
{
    public void ConnectStringTest()
    {


        string connetionString = null;
        SqlConnection cnn = new SqlConnection();
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


    private static string ConnectionString()
    {
        return "Server= localhost; Database= EisenhowerMatrix; Integrated Security=SSPI;";
    }

    public static DataSet GetTasksDataset(string queryString)
    {
        string connectionString = ConnectionString();
        DataSet dataset = new DataSet("Tasks");
        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                queryString, connection);
            adapter.Fill(dataset, "TASKS");
            return dataset;

        }
    }

    public static DataTable PrintMatrix(DataSet dataset)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        dt.Columns.Add("Importance");
        dt.Columns.Add("Urgent");
        dt.Columns.Add("Not Urgent");
        bool firstImportant = true;
        bool firstNonImportant = true;


        foreach (DataRow row in dataset.Tables["Tasks"].Rows)
        {
            string TaskName = row[1].ToString();
            if (row[2].ToString() == "Urgent" & row[3].ToString() == "Important" & firstImportant)
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Important";
                _row["Urgent"] = TaskName;
                _row["Not Urgent"] = " ";
                dt.Rows.Add(_row);
                firstImportant = false;
            }

            if (row[2].ToString() == "Urgent" & row[3].ToString() == "Important" & !firstImportant)
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = " ";
                _row["Urgent"] = TaskName;
                _row["Not Urgent"] = " ";
                dt.Rows.Add(_row);

            }

            if (row[2].ToString() == "Not Urgent" & row[3].ToString() == "Important" & firstImportant)
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Important";
                _row["Urgent"] = " ";
                _row["Not Urgent"] = TaskName;
                dt.Rows.Add(_row);
                firstImportant = false;
            }

            if (row[2].ToString() == "Not Urgent" & row[3].ToString() == "Important" & firstNonImportant)
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Not Important";
                _row["Urgent"] = " ";
                _row["Not Urgent"] = TaskName;
                dt.Rows.Add(_row);
                firstNonImportant = false;
            }

            if (row[2].ToString() == "Urgent" & row[3].ToString() == "Important" & !firstNonImportant)
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = " ";
                _row["Urgent"] = TaskName;
                _row["Not Urgent"] = " ";
                dt.Rows.Add(_row);
            }

        }

        return dt;

    }

    public static void AddTask(int TaskID, string TaskName, string TaskImportance, DateTime TaskDeadline)
    {
        string connectionString = ConnectionString();
        string TaskUrgency = "Urgent"; //TO DO Placeholder
        string queryString =
            "INSERT INTO TASKS(TaskID, TaskName,TaskImportance,TaskUrgency,TaskDeadline) VALUES(@TaskID,@TaskName,@TaskImportance,@TaskUrgency,@TaskDeadline)";

        //DataSet dataset = new DataSet("Tasks");
        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {
            
            SqlCommand _query = new SqlCommand(queryString, connection);
            _query.Parameters.AddWithValue("@TaskID", TaskID);
            _query.Parameters.AddWithValue("@TaskName", TaskName);
            _query.Parameters.AddWithValue("@TaskImportance", TaskImportance);
            _query.Parameters.AddWithValue("@TaskUrgency", TaskUrgency);
            _query.Parameters.AddWithValue("@TaskDeadline", TaskDeadline);
            
            
            _query.Connection.Open();
            _query.ExecuteNonQuery();
            _query.Connection.Close();


        }
        Console.WriteLine("Done adding");
    }
}

