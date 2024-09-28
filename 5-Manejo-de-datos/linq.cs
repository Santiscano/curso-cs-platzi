using System.linq;

var fruits = new string[] { "apple", "banana", "mango", "orange", "passionfruit", "grape", "mango verde", "mango tomy" };

var mangoList = fruits.Where(fruit => fruit.StartWith("mango")).ToList(); // busca los elementos que empiezan con mango y los guarda en lista con ToList
mangoList.ForEach(mango => Console.WriteLine(mango)); // recorre la lista y muestra los elementos

var mangoList = fruits.where(fruit => fruit.contains("mango"));