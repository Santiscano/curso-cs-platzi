
LinqQueries queries = new LinqQueries();

// Obtenemos todos los libros
//PrintBooks( queries.GetBooks() );

// Libros despues del 2000
//PrintBooks( queries.GetBooksAfter2000() );

// Libros que tienen mas de 250 pags y tienen en el titulo la palabra in action
//PrintBooks( queries.GetBooksMore250PagesAndInAction() );

// obtener Todos los libros que tienen un valor en Status
//Console.WriteLine( $" Tienen todos los libros un status? - {queries.AllBooksHaveStatus()}" );

// Si algun libro fue publicado en 2005
//Console.WriteLine($" Hay algun libro publicado en 2005? - {queries.AnyBookPublishedIn2005()}");

//Libros de categoria python
//PrintBooks( queries.booksCategoryPython() );
// Libros definiendo categoria
//PrintBooks( queries.booksByCategory("Java") );

//libros de Java ordenados por nombre
//PrintBooks( queries.booksJavaOrderedByName() );

//libros que tienen mas de 450 paginas ordernados por cantidad de paginas
// PrintBooks( queries.booksMore450PagesOrderedByPageCount() );

//los 3  libros de Java publicados recientemente
// PrintBooks( queries.threeFirstBooksOrderByDate() );

//tercer y cuarto libro con mas de 400 paginas
// PrintBooks( queries.threeAndFourtBookWithMore400Pages() );

//titulo y numero paginas de los tres primeros libros filtrados
// PrintBooks( queries.titlePageThreeFirstBooks() );

//cantidad de libros que tienen entre 200 y 500 paginas
// Console.WriteLine( queries.countBooksBetween(200, 500) );

// menor fecha de publicacion de todos los libros
// Console.WriteLine( queries.oldPublicationDate() );

//Numero de paginas del libro con mayor Numero de paginas
// Console.WriteLine( $"El libro con mas paginas tiene: {queries.bookLargestNumberPages()}" );

//Libro con menor numero de paginas
// Book bookPage = queries.BookWithLowerNumPage();
// Console.WriteLine( $"{bookPage.Title} - {bookPage.PageCount}" );

//Libro con fecha publicacion mas reciente
// var bookMoreRecently = queries.bookMoreRecently();
// Console.WriteLine($"{bookMoreRecently.Title} - {bookMoreRecently.PublishedDate.ToShortDateString()}");

//suma de paginas de libros entre 0 y 500
// Console.WriteLine($"Suma total de paginas: {queries.addPages()}");

//Libros publicados despues del 2015
// *uso de funciones
Func<Book, bool> conditionWhere = (x => x.PublishedDate.Year > 2005 && x.Title != string.Empty);
var titles1 = queries.titleBooksAftertwothousandfiveteenV1(conditionWhere);
var titles2 = queries.titleBooksAftertwothousandfiveteenV2(conditionWhere);
Console.WriteLine($"version 1: {titles1}");
Console.WriteLine($"version 2: {titles2}");


//el promedio de caracteres del los titulos de los libros
//Libros publicados a partir del 2000 agrupados por ano
//Diccionario de libros agrupados por primera letra del titulo



void PrintBooks(IEnumerable<Book> listBooks)
{
     Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Num Pages", "Published Date");
    foreach (var item in listBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
