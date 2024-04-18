using SQLite;

namespace OliveNoteMaui.Models;

public abstract class TableData
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}
