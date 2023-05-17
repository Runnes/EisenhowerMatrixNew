// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Runtime.InteropServices.JavaScript;
using EisenhowerMatrixNew;

// // TodoItem karol = new TodoItem("karoltest",DateTime.Now);
// // Console.WriteLine(karol.ToString());
// TodoQuarter mylist = new TodoQuarter(); //nowa instancja ToDoQuarter
// mylist.AddItem("karoltest", DateTime.Now); //uzycie metody Add item z TodoQuarter klasy do dodania tasku do listy wewnatrz TodoQuarter
// mylist.AddItem("karoltest222", DateTime.Now);//uzycie metody Add item z TodoQuarter klasy do dodania tasku do listy wewnatrz TodoQuarter
// TodoItem Task = new TodoItem("karoltest22233555", DateTime.Now);
// Task.Mark();
// mylist.AddItem(Task.GetTitle(),Task.GetDeadline());//testowanie Additems przez TodoItem, a nie bezposrednie z todoquarter
// TodoItem testMark = mylist.GetItem(1); //znajduje item
// testMark.Mark(); //markuje jako done
// Console.WriteLine(testMark.isDone); //wyswietla status
// // foreach (var todoItem in mylist.GetItems()) //dla kazdego elementu listy ( a to sa obiekty typu todoItem (nie proste jak w pythonie :/) wywoluje funkcje do wziecia titla - bo nie mozna zwykle tego accesowac bo jest private
// //
// // {
// //     Console.WriteLine(todoItem.GetTitle());
// // }
// List <string> myNew_list = mylist.ToString();
// foreach (var s in myNew_list)
// {
//     Console.WriteLine(s);
// }

// TodoMatrix karoltest = new TodoMatrix();
// // TodoQuarter karolx = new TodoQuarter();
// karoltest.AddItem("karoltest",DateTime.Today);
// karoltest.AddItem("karoltest",DateTime.Today,false);
// // Console.WriteLine(karoltest.GetStatus(DateTime.Today, false));
// Console.WriteLine(karoltest.GetQuarters()["NU"]);
// Console.WriteLine(karoltest.Geti);
// foreach (var x in karoltest.GetQuarters())
// {
//     try
//     {
//         Console.WriteLine(x.Key);
//         Console.WriteLine(x.Value.GetItem(0));
//     }
//     finally
//     {
//         Console.WriteLine("test try");
//     }
// }
// karoltest.IsUrgent(1);

var lines = ConnectionSQL.CreateCommand("SELECT * FROM TASKS");
// while (lines.Read()){
//     Console.WriteLine(String.Format("{0}", lines[0]));
// }
// ConnectionSQL.CreateCommand("INSERT INTO TASKS ");
// ;
 // Console.WriteLine(lines);
DataSet dataSet = new DataSet("Suppliers");
DataSet data = ConnectionSQL.SelectRows(dataSet, "SELECT * FROM TASKS");
DataRow dataRow = data.Tables[0].Rows[0];
// Console.WriteLine(data.Tables[0].Rows[0][2]);
foreach (DataRow cell in data.Tables[0].Rows)
{
 Console.WriteLine(cell);
}
// foreach (var row in data.Tables["TASKS"].Rows)
//  
// {
//  try
//  {
//   Console.WriteLine(row);
//   Console.WriteLine(row.ToString());
//
//  }
//  finally
//  {
//   Console.WriteLine("karol");
//  }
// }


// Console.WriteLine(dataRow["TaskName"]);




