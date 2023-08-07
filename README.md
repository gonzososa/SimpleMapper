## SimpleMapper

Aims to help to set values from a source object into another. Simply, by decorating target class and every property with an attribute that address its data origin.

### Usage

Supose you have a class with next structure.

```C#
namespace SimpleMapper.Models;

public class Source {
    public string id { get; set; }
    public string SourceCode { get; set; }
    public Document Document { get; set; }
    public string Date { get; set; }
    public Address Address { get; set; }
}

namespace SimpleMapper.Models;

public class Document {
    public string ID { get; set; }
}

namespace SimpleMapper.Models
{
	public class Address
	{
		public string Street { get; set; }
		public string Country { get; set; }
	}
}

```

To map it to another class only next is needed

```C#
namespace SimpleMapper.Models;

[MapClass ("Source")]
public class Target {
    [MapProperty ("id")]
    public string TargetId { get; set; }

    [MapProperty ("SourceCode")]
    public string TargetCode { get; set; }

    [MapProperty ("Document.ID")]
    public string Document { get; set; }

    [MapProperty ("Date")]
    public string Date { get; set; }

    [MapProperty ("Address")]
    public Address Address { get; set; }

    public override string ToString ()
    {
        return $"Id: {TargetId}\nCustomerCode:{TargetCode}\nJobsite:{Document}\nDate:{Date}\nAddress: {Address.Country}";
    }
}                                                                       
```
> [!NOTE]
> At this point only one hierarchy level is supported. It'll be fixed in 
next commits.

Requirements
```
  - Linux, MacOS or Windows
  - dotnet 7.0
```

build
```
  dotnet restore
  dotnet build
  dotnet run
```
