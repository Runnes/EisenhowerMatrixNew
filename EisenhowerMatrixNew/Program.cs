// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.JavaScript;
using System.Xml.Schema;
using EisenhowerMatrixNew;
using Spectre.Console;
using SpectreTable = Spectre.Console.Table;
using Spectre.Console.Extensions.Table;

ConnectionSQL.AddTask(5,"TestADD","Not Important",DateTime.Now);
DataSet data = ConnectionSQL.GetTasksDataset( "SELECT * FROM TASKS");
var table = ConnectionSQL.PrintMatrix(data);
DataTable dt = data.Tables["TASKS"];

var table2 = table.FromDataTable().Border(TableBorder.Rounded);
AnsiConsole.Render(table2);

// AnsiConsole.Write(table);
// AnsiConsole.Write(table);
//Console.WriteLine(table.Rows[0][0]);

// foreach (DataRow dr in dt.Rows)
// {
//  
//  // Console.WriteLine(dr["TaskId"].ToString(),dr["TaskName"],dr["TaskUrgency"].ToString(),dr["TaskImportance"].ToString(),dr["TaskDeadline"].ToString(),dr["TaskStatusDone"].ToString(),dr["TaskStatusArchived"].ToString());
//
// }





