namespace EisenhowerMatrixNew;

public class TodoMatrix 
{
    private Dictionary<string, TodoQuarter> todoQuarters = new Dictionary<string, TodoQuarter>();
    public TodoMatrix()
    {
        todoQuarters.Add("IU", new TodoQuarter());
        todoQuarters.Add("IN", new TodoQuarter());
        todoQuarters.Add("NU", new TodoQuarter());
        todoQuarters.Add("NN", new TodoQuarter());
    }

    public Dictionary<string, TodoQuarter> GetQuarters()
    {
        return todoQuarters;
    }

    public TodoQuarter GetQuarter(string status)
    {
        return todoQuarters[status];

    }

    public void AddItem(string title, DateTime deadline, bool isImportant)
    {
        TodoQuarter item = new TodoQuarter();
        // todoQuarters.Add("IU",item.AddItem(title,deadline));
       
       
    }

    public bool IsUrgent(int id)
    {
        TodoQuarter item = new TodoQuarter();
        TodoItem itemStatus = item.GetItem(id);
        DateTime itemDeadline = itemStatus.GetDeadline();
        switch (DateTime.Compare(itemDeadline.Date ,DateTime.Today))
        {
            case <=3:
                return false;
            case >3:
                return true;
            
        }



    }

    public string GetStatus(bool isImportant, bool isUrgent ) //TODO 

    {
        var x = 0;
        // switch (isImportant 
        // {
        //     case "":
        //         break;
        // }
    }

}