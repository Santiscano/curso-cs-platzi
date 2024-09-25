// como estandar se nombran con una I al principio de la interfaz "IsuperHero"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroApp.Interfaces
{
    internal interface IsuperHero
    {
        int Id { get; set; }
        string Name { get; set; }
        string IdentitySecret { get; set; }
    }

    internal interface IHuman
    {
        string Name { get; set; }
        string LastName { get; set; }
        string FullName();
    }
}

class SuperMan : IsuperHero, IHuman
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IdentitySecret { get; set; }
    public string LastName { get; set; }

    public string FullName()
    {
        return $"{Name} {LastName}";
    }
}

SuperMan superman = new SuperMan();
superman.Id = 1;
superman.Name = "Clark";
superman.LastName = "Kent";
superman.IdentitySecret = "Superman";
Console.WriteLine(superman.FullName()); // Clark Kent