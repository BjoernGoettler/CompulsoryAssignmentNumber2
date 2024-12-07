using System.ComponentModel.DataAnnotations;
using Database.Interfaces;

namespace Database.Models;

public class Author: IPerson
{
    [Key]
    public Guid Id { get;}
    public string Name { get; set; }
 
    public Author(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public Author()
    {
        Name = "";
        Id = Guid.NewGuid();
    }
}