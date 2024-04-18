using SQLite;
using SQLiteNetExtensions.Attributes;

namespace OliveNoteMaui.Models;

[Table("Olives")]
public class Olive : TableData
{
    [NotNull] public string? Name { get; set; }
    public OliveOrigin Origin { get; set; }
    public DateTime Imported { get; set; }
    public DateTime Planted { get; set; }
    // [OneToOne]
    // public Note OliveNote { get; set; }
    // [ForeignKey(typeof(Note))]
    // public int OliveNoteId { get; set; }
}
