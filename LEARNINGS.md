# Things I learned, that could have spared me a lot of time

## EntityFramework

Be aware of version mismatches. Your Project might be bleeding edge with the newest version of dotnet and C#, but the NuGet Packages might not be as updated:

```text
Database -> Microsoft.EntityFrameworkCore.Design 9.0.0 -> Microsoft.EntityFrameworkCore.Relational (>= 9.0.0) 
 Database -> Pomelo.EntityFrameworkCore.MySql 8.0.2 -> Microsoft.EntityFrameworkCore.Relational (>= 8.0.2 && <= 8.0.999).
```

I thougt I was smart when i deleted the automated Setter method on a property, because why on earth would you set an Id otherwhere than in the constructor:

```csharp
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
```
Even with the explicitly Key-tagged, Id property, EF cursed at me saying:
```text
Unable to create a 'DbContext' of type ''. The exception 'The entity type 'Author' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
```

The "fix" was to give it back its automated Setter