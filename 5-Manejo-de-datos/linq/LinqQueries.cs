using System.Xml.Schema;

public class LinqQueries
{
    // instanciamos una lista de libros del tipo book que es la clase que creamos en Books.cs
    // con new List<Book>(); definimos que el valor no sera nulo sino un valor vacio.
    private List<Book> booksCollections = new List<Book>();


    public LinqQueries()
    {
        // new StreamReader("books.json") hace referencia al archivo books.json que esta en la raiz del proyecto
        // El bloque using asegura que el StreamReader se cierre correctamente y libere los recursos del archivo cuando termines de usarlo, incluso si ocurre un error. Esto es importante para no mantener archivos abiertos innecesariamente.
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd(); // leemos el archivo json
            // System.Text.Json.JsonSerializer.Deserialize<T>: Este metodo toma una cadena en formato JSON (json en este caso) y la deserializa (convierte) en un objeto o coleccion de objetos de tipo T. En tu caso, T es List<Book>, lo que significa que convierte el JSON en una lista de objetos de tipo Book.
            // List<Book>: Aqui le estas diciendo a Deserialize que espere que el JSON sea una representacion de una lista de objetos Book.
            this.booksCollections = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(
                // json: Es la cadena que contiene el contenido del archivo JSON.
                json, 
                // El segundo parametro es para vincular el json que esta en camelCase con la clase Book que esta en PascalCase
                // JsonSerializerOptions Esta es una clase que te permite configurar opciones sobre como se deserializa el JSON. Aqui estas creando una nueva instancia de JsonSerializerOptions con una propiedad especifica.
                // PropertyNameCaseInsensitive = true: Esta opcion le dice al deserializador que ignore las diferencias de mayusculas y minusculas en los nombres de las propiedades del JSON. Es decir, si tu archivo JSON tiene algo como "title": "Some Book" y tu clase Book tiene una propiedad llamada Title (con mayuscula inicial), el deserializador aun podra hacer la correspondencia entre "title" en el JSON y Title en la clase Book. Esto es util porque en muchos casos, los nombres de las propiedades pueden tener diferencias en mayusculas y minusculas entre el codigo C# y el JSON.
                new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
             ) ?? Enumerable.Empty<Book>().ToList();
            //this.booksCollections = JsonConvert.DeserializeObject<List<Book>>(json);
        }
    }

    public IEnumerable<Book> GetBooks()
    {
        return this.booksCollections;
    }

    public IEnumerable<Book> GetBooksAfter2000()
    {
        // extension method
        // return this.booksCollections.Where(x => x.PublishedDate.Year > 2000);

        // query expresion
        return from l in this.booksCollections
               where l.PublishedDate.Year > 2000
               select l;
    }

    public IEnumerable<Book> GetBooksMore250PagesAndInAction()
    {
        // extension method
        return this.booksCollections.Where(x => x.PageCount > 250 && x.Title.Contains("in Action") );

        // query expresion
        //return from l in this.booksCollections
        //       where l.PageCount > 250 && l.Title.Contains("in Action")
        //       select l;
    }

    //public List<char> vocales = new List<char> { 'a', 'e', 'i', 'o', 'u' };
    //public IEnumerable<Animales> getGreenAnimals()
    //{
    //    return this.animales.Where( 
    //        an => an.Color.ToLower().Equals("verde") &&
    //              vocales.Contains( an.Nombre.ToLower()[0] )
    //    ).ToList();
    //}

    public bool AllBooksHaveStatus()
    {
        return booksCollections.All(x => x.Status != string.Empty);
    }

    public bool AnyBookPublishedIn2005()
    {
        return booksCollections.Any(x => x.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> booksCategoryPython()
    {
        return booksCollections.Where( x => x.Categories.Contains("Python") );
    }

    public IEnumerable<Book> booksByCategory(string category)
    {
        return booksCollections.Where( x => x.Categories.Contains(category) );
    }

    public IEnumerable<Book> booksJavaOrderedByName()
    {
        return booksCollections.Where(x => x.Categories.Contains("Java")).OrderBy(x => x.Title);
    }

    public IEnumerable<Book> booksMore450PagesOrderedByPageCount()
    {
        return booksCollections.Where(x => x.PageCount > 450).OrderByDescending(x => x.PageCount);
    }

    // private List<Animal> void animales = new List<Animal>(); // inicializa una lista vacia
    // animales.Add(new Animal() { Nombre: "Hormiga", Color: "Rojo"});
    // animales.Add(new Animal() { Nombre: "Lobo", Color: "Gris"});
    // // como estas se crean mas.....
    // public AnimalsOrderedByName()
    // {
    //     return animales.OrderBy(x => x.Nombre);
    // }
    // public resultAnimals = AnimalsOrderedByName();
    // resultAnimals.ToList().ForEach(animal => Console.WriteLine(animal.Nombre));

    public IEnumerable<Book> threeFirstBooksOrderByDate()
    {
        return booksCollections
            .Where(p => p.Categories.Contains("Java"))
            // *forma 1 - take
            // .OrderByDescending(p => p.PublishedDate)
            // .Take(3);
            // *forma 2 - takeLast
            .OrderBy(p => p.PublishedDate)
            .TakeLast(3);
            // *takeWhile
            // .TakeWhile(p => p.PageCount > 150); // traeria todos los que encuentre hasta que la condicion no se cumpla
    }

    public IEnumerable<Book> threeAndFourtBookWithMore400Pages()
    {
        return booksCollections
            .Where(l => l.PageCount > 400)
            .Take(4)
            .Skip(2);
            // SkipLast()
            // SkipWhile()
    }

    public IEnumerable<Book> titlePageThreeFirstBooks()
    {
        return booksCollections
            .Select(book => new Book() { Title = book.Title, PageCount = book.PageCount })
            // .Select(book => new Book() { book.Title, book.PageCount })
            .Take(3);
    }

    public int countBooksBetween(int start, int ending)
    {
        return booksCollections.Count( b => b.PageCount >= start && b.PageCount <= ending );
        // return booksCollections.LongCount( b => b.PageCount >= start && b.PageCount <= ending );
    }

    public DateTime oldPublicationDate()
    {
        return booksCollections.Min( d => d.PublishedDate );
    }

    public int bookLargestNumberPages()
    {
        return booksCollections.Max( p => p.PageCount); // se pone ?? 0 porque el valor q
    }

    public Book BookWithLowerNumPage()
    {
        return booksCollections
            .Where( b => b.PageCount > 0)
            .MinBy( b => b.PageCount);
    }

    public Book bookMoreRecently()
    {
        return booksCollections.MaxBy(p => p.PublishedDate);
    }

    public int addPages()
    {
        return booksCollections
            .Where(p => p.PageCount >= 0 && p.PageCount <= 500)
            .Sum( t => t.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return booksCollections
                .Where(p => p.PublishedDate.Year > 2015)
                .Aggregate("", (TitulosLibros, next) =>
                {
                    if (TitulosLibros != string.Empty)
                        TitulosLibros += " - " + next.Title;
                    else
                        TitulosLibros += next.Title;

                    return TitulosLibros;
                });
    }

    public string titleBooksAfterTwoThousandFifteenV1(Func<Book, bool> where)
        => string.Join(" - ", this.booksCollections.Where(where).Select(x => x.Title));

    public string titleBooksAftertwothousandfiveteenV2(Func<Book, bool> where)
    {
        return this.booksCollections.Where(where).Aggregate("",
            (acc, next) => acc + (!string.IsNullOrEmpty(acc) ? $" - {next.Title}" : next.Title));
    }

    public double Challenge()
    {
        return this.booksCollections
            .Where(b => b.PageCount > 0)
            .Average(b => b.PageCount);
    }

    public double AverageTitleLength()
    {
        return this.booksCollections
            .Where(b => b.Title.Length > 0)
            .Average(b => b.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> BooksAfterTwoThousand()
    {
        return this.booksCollections
            .Where(b => b.PublishedDate.Year >= 2000)
            .GroupBy(b => b.PublishedDate.Year);
    }

    public ILookup<char, Book> DicctionaryTitlesBooks()
    {
        return this.booksCollections.ToLookup(b => b.Title[0], p => p);
    }

    public IEnumerable<Book> sentenceWithJoin()
    {
        var booksAfterTwoThousand = this.booksCollections.Where(b => b.PublishedDate.Year >= 2000);
        var booksWithMoreFourhundredPages = this.booksCollections.Where(b => b.PageCount > 400);

        return booksAfterTwoThousand
            .Join(booksWithMoreFourhundredPages, b1 => b1.Title, b2 => b2.Title, (b1, b2) => b1);
    }
}