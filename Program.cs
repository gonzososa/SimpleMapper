using SimpleMapper.Models;
using SimpleMapper.Utils.Mapper;

var q = new Source {
    id = Guid.NewGuid ().ToString (),
    SourceCode = "12456",
    Document = new Document {
        ID = Guid.NewGuid ().ToString ()
    },
    Date = DateTime.Now.ToString (),
    Address = new Address
    {
        Country = "MX",
        Street = "Reforma #301"
    }
};

var inputData = Mapper.Map<Target>(q);

Console.WriteLine ("\nProgram output:\n");
Console.WriteLine (inputData.ToString ());
Console.ReadKey ();
