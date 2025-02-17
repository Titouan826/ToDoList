using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiTest.Entity;

public class TodoItem
{
    //[JsonPropertyName("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    //[JsonPropertyName("Name")]
    [MaxLength(255)]
    public string? Name { get; set; }

    //[JsonPropertyName("isComplete")]
    public bool IsComplete { get; set; }

    //[JsonPropertyName("secret")]
    [MaxLength(255)]
    public string? Secret { get; set; }

    public TodoItem( long id, string? name, bool isComplete, string? secret)
    {
        Id = id;
        Name = name;
        IsComplete = isComplete;
        Secret = secret;
    }
    public TodoItem() : this(0,string.Empty, false, string.Empty) { }
}