
public record SuperHeroRecord (int Id, string Name, string IdentitySecret);

SuperHeroRecord superman1 = new SuperHeroRecord(1, "Superman", "Clark Kent");
SuperHeroRecord superman2 = new (1, "Superman", "Clark Kent"); // ambas formas son válidas

Console.WriteLine(superman1 == superman2); // True