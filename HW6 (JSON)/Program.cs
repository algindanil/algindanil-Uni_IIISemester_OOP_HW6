
using System.Diagnostics.Contracts;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



public class PublishingHouse
{
    [JsonPropertyName("Id")]
    public int PublishingHouseId { get; set; }
    [JsonPropertyName("Name")]
    public string PublishingHouseName { get; set; }
    [JsonPropertyName("Adress")]
    public string PublishingHouseAdress { get; set; }

}

class Book
{
    [JsonIgnore] //for question 2
    public int PublishingHouseId { get; set; }
    [JsonPropertyName("Title")] //for question 3
    public string Name { get; set; }
    [JsonPropertyName("PublishingHouse")]
    public PublishingHouse publishingHouse { get; set; }
}

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        string path = "C:\\Users\\Danylo\\Desktop\\Uni\\III Semester\\Programming\\HW\\HW6 (JSON)\\HW6 (JSON)\\jsconfig1.json";
        string outputPath = "C:\\Users\\Danylo\\Desktop\\Uni\\III Semester\\Programming\\HW\\HW6 (JSON)\\HW6 (JSON)\\output.txt";
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        StreamWriter output = new StreamWriter(outputPath);
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(fs, options);

        foreach (Book a in books)
        {
            
            output.Write(JsonSerializer.Serialize<Book>(a, options));
            
        }
        output.Flush();
        fs.Close();
    }
}
