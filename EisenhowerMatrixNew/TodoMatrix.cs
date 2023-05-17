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

    public void AddItem(string title, DateTime deadline, bool isImportant = false)
    {
        string status = GetStatus(deadline, isImportant);
        todoQuarters[status] = new TodoQuarter();
    }
    //
    // public bool IsUrgent(int id)
    // {
    //     TodoQuarter item = new TodoQuarter();
    //     TodoItem itemStatus = item.GetItem(id);
    //     DateTime itemDeadline = itemStatus.GetDeadline();
    //     switch (DateTime.Compare(itemDeadline.Date ,DateTime.Today))
    //     {
    //         case <=3:
    //             return false;
    //         case >3:
    //             return true;
    //         
    //     }
    //
    //
    //
    // }

    public string GetStatus(DateTime deadline, bool isImportant) //TODO 
    {
        DateTime today = DateTime.Now;
        TimeSpan ts = deadline - today;
        switch (ts.Days)
        {
            case <= 3:
                if (isImportant)
                {
                    return "IU";
                }

                return "NU";
            case > 3:
                if (isImportant)
                {
                    return "IN";
                }

                return "NN";

        }
    }

}