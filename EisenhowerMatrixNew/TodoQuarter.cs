using System.Runtime.InteropServices.JavaScript;

namespace EisenhowerMatrixNew;

public class TodoQuarter
{
    private List<TodoItem> toDoItems; //Lista obiektow TYPU ToDoItem (title, deadline, isdone)

    //Constructor
    public TodoQuarter() //Ta sama nazwa co klasa - ta sama wielkosc liter tez
    {
        toDoItems = new List<TodoItem>();
    }

    public void AddItem(string title, DateTime deadline)
    {
        TodoItem item = new TodoItem(title, deadline); //nowa instancja ToDoItem klasy
        toDoItems.Add(item);
        
    }



    public void RemoveItem(int index)
    {
        toDoItems.RemoveAt(index); //Removes at index (index), .Remove usuwa po wartosci, nie po indeksie
    }

    public void ArchiveItems()
    {
        foreach (var todoItem in toDoItems)
        {
            toDoItems.RemoveAll(element => element.isDone); //bardzo fajna konstrukcja usuwajaca wszystkie itemy ktora spelniaja isDone == true, mozna to tez prostym ifem zrobic i for each, ale tu ladniejsze
        }
    }

    public TodoItem GetItem(int index)
    {
        return toDoItems[index];
    }

    public List<TodoItem> GetItems()
    {
        return toDoItems;
    }

    public List<string> ToString()
    {
        List<string> fullList = new List<string>();
        foreach (var todoItem in toDoItems)
        {
            switch (todoItem.isDone)
            {
                case true:
                    fullList.Add($"\u2713 {todoItem.GetDeadline().ToString("d-M")} {todoItem.GetTitle()}");
                    break;
                case false:
                    fullList.Add( $"[ ] {todoItem.GetDeadline().ToString("d-M")} {todoItem.GetTitle()}");
                    break;
            }
            
        }

        return fullList;

    }
}