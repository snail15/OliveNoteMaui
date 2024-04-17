using SQLite;

namespace OliveNoteMaui.Models;

[Table("Notes")]
public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public Olive Olive { get; set; }
}
