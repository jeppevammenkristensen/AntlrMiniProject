# AntlrMiniProject
A small project/playground to explore Antlr

## Shortly about the parser

You can define that you want to create a class, record or interface.

`create class TestClass with property Id:int Name:string DateOfBirth:DateTime`

Will produce 

```csharp
public class TestClass
{
        public int Id {get; set; }
        public string Name {get; set; }
        public DateTime DateOfBirth {get; set; }
}
```

`create record TestClass with property Id:int Name:string DateOfBirth:DateTime`

Will produce

```csharp
public record TestClass(int Id,string Name,DateTime DateOfBirth)
```

`create interface ITestInterface with property Id:int Name:string DateOfBirth:DateTime`

Will produce

```csharp
public interface ITestInterface
{
        int Id {get; set; }
        string Name {get; set; }
        DateTime DateOfBirth {get; set; }
}
```
