namespace SimpleMapper.Models;

public class Source {

    public string id { get; set; }
    public string SourceCode { get; set; }
    public Document Document { get; set; }
    public string Date { get; set; }
    public Address Address { get; set; }

}