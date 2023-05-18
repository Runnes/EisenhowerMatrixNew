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
            if (row[2].ToString() == "Urgent" & row[3].ToString() == "Important")
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Important";
                _row["Urgent"] = TaskName;
                _row["Not Urgent"] = " ";
                dt.Rows.Add(_row);
                firstImportant = false;
            }

            if (row[2].ToString() == "Urgent" & row[3].ToString() == "Not Important")
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Not Important";
                _row["Urgent"] = TaskName;
                _row["Not Urgent"] = " ";
                dt.Rows.Add(_row);
                firstImportant = false;
            }

            if (row[2].ToString() == "Not Urgent" & row[3].ToString() == "Not Important")
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Not Important";
                _row["Urgent"] = " ";
                _row["Not Urgent"] = TaskName;
                dt.Rows.Add(_row);
                firstImportant = false;
            }

            if (row[2].ToString() == "Not Urgent" & row[3].ToString() == "Important")
            {
                DataRow _row = dt.NewRow();
                _row["Importance"] = "Important";
                _row["Urgent"] = " ";
                _row["Not Urgent"] = TaskName;
                dt.Rows.Add(_row);
                firstImportant = false;
            }


            

        }
        return dt;
    }

    public static void SQLAddTask(string TaskName, string TaskImportance, DateTime TaskDeadline)
    {
        int TaskID = GetRows();
        string connectionString = ConnectionString();
        string TaskUrgency = GetUrgency(TaskDeadline);
        string queryString =
            "INSERT INTO TASKS(TaskID, TaskName,TaskImportance,TaskUrgency,TaskDeadline) VALUES(@TaskID,@TaskName,@TaskImportance,@TaskUrgency,@TaskDeadline)";

        //DataSet dataset = new DataSet("Tasks");
        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {
            
            SqlCommand _query = new SqlCommand(queryString, connection);
            _query.Parameters.AddWithValue("@TaskID", TaskID+1);
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

    public static string GetUrgency(DateTime taskDeadline)
    
    { 
        double result = (taskDeadline - DateTime.Now).TotalDays;
        if (result > 3)
        {
            return "Not Urgent";
        }
        return "Urgent";
    }

    public static void AskForTask()
    {
        Console.WriteLine("Enter Task Name:");
        string TaskName= Console.ReadLine();
        Console.WriteLine("Enter Task Importance:");
        string TaskImportance= Console.ReadLine();
        Console.WriteLine("Enter Task Deadline:");
        string TaskDeadline= Console.ReadLine();
        DateTime _TaskDeadline = DateTime.Parse(TaskDeadline);
        
        
        SQLAddTask(TaskName,TaskImportance,_TaskDeadline);

    }

    interface IAskForTask
    {
        int TaskId();
        
    }

    public static int GetRows()
    {
        string connectionString = ConnectionString();
        string queryString =
            "SELECT COUNT(*) FROM TASKS";

        //DataSet dataset = new DataSet("Tasks");
        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {

            SqlCommand _query = new SqlCommand(queryString, connection);
            _query.Connection.Open();
            // _query.ExecuteNonQuery();
            string RowCounter = _query.ExecuteScalar().ToString();
            _query.Connection.Close();
            return Int32.Parse(RowCounter);

        }

        
    }

    public static void SQLChangeStatus(int _TaskId)

    {
        string connectionString = ConnectionString();
        string queryString =
            "UPDATE TASKS SET TaskStatusDone = 1 WHERE TaskId = @TaskId";
        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {
            SqlCommand _query = new SqlCommand(queryString, connection);
            _query.Parameters.AddWithValue("@TaskId",_TaskId);
            _query.Connection.Open();
            _query.ExecuteNonQuery();
            _query.Connection.Close();

        }
        
    }
    

}

