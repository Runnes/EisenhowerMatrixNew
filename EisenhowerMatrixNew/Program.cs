// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Runtime.InteropServices.JavaScript;
using EisenhowerMatrixNew;


DataSet data = ConnectionSQL.GetTasksDataset( "SELECT * FROM TASKS");
DataTable dt = data.Tables["TASKS"];

foreach (DataRow dr in dt.Rows)
{
 Console.WriteLine(dr["TaskName"].ToString());
}





