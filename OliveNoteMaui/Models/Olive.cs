using SQLite;

namespace OliveNoteMaui.Models;

[Table("Olives")]
public class Olive
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Indexed, NotNull]
    public string Name { get; set; }
    public OliveOrigin Origin { get; set; }
    public DateOnly Imported { get; set; }
    public DateOnly Planted { get; set; }
    public Note Note { get; set; }
    
}
