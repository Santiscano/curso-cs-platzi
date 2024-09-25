class SuperHero 
{
    public int Id;
    public string Name { get; set; };
    public string IdentitySecret;
    public List<SuperPower> SuperPowers;
    public bool CanFly;

    public SuperHero() 
    {
        CanFly = false;
        SuperPowers = new List<SuperPower>();
    }

    public void UsePowers() 
    {
        foreach (var power in SuperPowers) 
        {
            Console.WriteLine($"Using {power.Name} power");
        }
    }

    public void UseOnePower(string powerName) 
    {
        var power = SuperPowers.FirstOrDefault(p => p.Name == powerName);
        if (power != null) 
        {
            Console.WriteLine($"Using {power.Name} power");
        }
    }

    public string sendSuperPowers() 
    {
        string powers = "";
        foreach (var power in SuperPowers) 
        {
            powers += power.Name + ", ";
        }
        return powers;
    }

    public string sendSuperPowersStrBuilder()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var power in SuperPowers) 
        {
            sb.Append($"{Name} using {power.Name}, ");
        }
        return sb.ToString();
    }
}

class SuperPower 
{
    public string Name;
    public string Description;
    public int Level;
}

enum LevelPower 
{
    Low = 1,
    Medium = 2,
    High = 3
}

// *instanciarpoderes
var powerFly = new SuperPower();
powerFly.Name = "Fly";
powerFly.Description = "The ability to fly in the air";
powerFly.Level = LevelPower.Low;

var powerStrength = new SuperPower();
powerStrength.Name = "Super strength";
powerStrength.Description = "The ability to lift heavy objects";
powerStrength.Level = LevelPower.High;

var powerHeatVision = new SuperPower();
powerHeatVision.Name = "Heat vision";
powerHeatVision.Description = "The ability to shoot heat rays from the eyes";
powerHeatVision.Level = LevelPower.Medium;

// *Instanciar poderes de superman
List<SuperPower> powersSuperman = new List<SuperPower>();
powersSuperman.Add(powerFly);
powersSuperman.Add(powerStrength);
powersSuperman.Add(powerHeatVision);

// *Instanciar superman
SuperHero superman = new SuperHero();
superman.Id = 1;
superman.Name = "Superman";
superman.IdentitySecret = "Clark Kent";
// superman.SuperPowers = new string[] { "Super strength", "Heat vision", "Flight" };
superman.SuperPowers = powersSuperman;
superman.CanFly = true;

// *Usar poderes
superman.UsePowers();