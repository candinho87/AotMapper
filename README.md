# 🧠 AotMapper

**AotMapper** is a lightweight and fast object-to-object mapper designed with full support for **AOT (Ahead-Of-Time) compilation**, making it ideal for environments like **.NET MAUI**, **Blazor WebAssembly**, and other platforms with reflection limitations.

## 🚀 Getting Started

### 1. Install the Package


dotnet add package SimpleAotMapper

📦 Model Example

Make sure to decorate your classes with the [AOTReflection] attribute to ensure compatibility with AOT.
```bash
namespace TestMapper;

[AOTReflection] // Required for AOT compilation!
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

[AOTReflection] // Required for AOT compilation!
public class PersonDTO
{
    public string Name { get; set; }
    public int Age { get; set; }
}

🔁 Mapping Objects

using SimpleAotMapper;
using TestMapper;

PersonDTO dto = new() { Name = "John Wick", Age = 37 };
Person person = Mapper.Map<PersonDTO, Person>(dto);

Console.WriteLine(person?.Name); // Output: John Wick

💡 Mapping Rules

    Only properties with the same name and compatible types are mapped.

    The mapping is based on convention, no configuration required.

    Properties not present in the destination type are ignored.

🔒 AOT Support

This mapper is fully compatible with AOT environments. All types involved in mappings must be decorated with [AOTReflection] to prevent the linker from stripping required metadata.

📋 Requirements

    .NET 6 or higher

    Works with both JIT and AOT compilation

    Need Apparatus.AOT.Reflection package

    
🤝 Contributing

Pull requests are welcome! Feel free to open issues or suggest improvements.


📜 License

This project is licensed under the MIT License.

Made with ❤️ by @candinho87
