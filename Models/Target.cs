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