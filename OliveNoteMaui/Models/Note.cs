using SQLite;
using SQLiteNetExtensions.Attributes;

namespace OliveNoteMaui.Models;

[Table("Notes")]
public class Note : TableData
{
   
    
    [OneToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead | CascadeOperation.CascadeDelete)]
    public Olive Olive { get; set; }
    
    [ForeignKey(typeof(Olive))]
    public int OliveId { get; set; }

    public string? NoteContent { get; set; }
}
