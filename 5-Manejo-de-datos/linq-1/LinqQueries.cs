public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>;


    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json")) // leer el archivo
        {
            string json = reader.ReadToEnd(); // leer el archivo completo
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }
    }

    public IEnumerable<Book> AllCollection()
    {
        return this.booksCollection;
    }
}