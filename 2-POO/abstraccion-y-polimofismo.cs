using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroApp.Models
{
    internal abstract class SuperHero // *es necesario que la clase sea abstracta para poder tener metodos abstractos
    {
        public string Name { get; set; }
        public abstract string SaveTheWorld(); // *no tiene implementacion, sino que cada hijo genera esta implementacion
        public virtual string specialPower() // *se puede sobreescribir en los hijos
        {
            return "Super power";
        }
    }

    internal class SuperMan : SuperHero
    {
        public override string SaveTheWorld() // *es necesario agregar override para poder sobreescribir el metodo abstracto
        {
            return "Superman is saving the world";
        }
        public override string specialPower() // *se puede sobreescribir en los hijos
        {
            return "Superman special power is flying and super strength";
        }
    }

    internal class Batman : SuperHero
    {
        public override string SaveTheWorld()
        {
            return "Batman is saving the world";
        }
        public override string specialPower() // *se puede sobreescribir en los hijos
        {
            // *base refiere a que se implementara lo que tenga la clase padre.
            return base.specialPower() + " and Batman special power is intelligence and technology";
        }
    }
}

// *instanciar superman
var superman = new SuperMan();
Console.WriteLine(superman.SaveTheWorld());

// *instanciar batman
var batman = new Batman();
Console.WriteLine(batman.SaveTheWorld());