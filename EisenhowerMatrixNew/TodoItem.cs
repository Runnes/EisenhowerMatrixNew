using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace EisenhowerMatrixNew;

public class TodoItem
{
    //Attributes - > Shouldn't those be named Fields?
    private string title; //description: title of todoItem
    private DateTime deadline; //description: deadline of todoItem, year is always set to 2020
    private bool isDone; //description: contains true if TODO item is done, otherwise contains false. Default value is false

    //Constructor
    public TodoItem(string Title, DateTime Deadline,bool IsDone =false)
    {
        title = Title;
        deadline = Deadline;
    }

    // public string Title  //->>>constructor parameters vs properties - Use parameterized constructor when your class instance cannot be created without those values. Any optional attributes of the instance can be set using properti
    // {
    //
    //     get { return title; }
    // }
    public string GetTitle()
    {
        return title;
    }

    public DateTime GetDeadline()
    {
        return deadline;
    }


    public void Mark()
    {
        isDone = true;
    }
    public void Unmark()
    {
        isDone = false;
    }

    public string ToString()
    {
        switch (isDone)
        {
               case true:
                   return $"[x] {deadline.ToString("d-M")} {title}";
               case false:
                   return $"[ ] {deadline.ToString("d-M")} {title}";
        }
    }
    
    
}
