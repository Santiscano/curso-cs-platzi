using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroApp.Models
{
    internal class
}

var wiz_1 = new Wizard("Gandalf", 200, 30);
var soldier_1 = new Swordsman("Orc", 50, 10);

wiz_1.Attack(soldier_1);

class Character
{
    protected string name;
    protected float health;
    protected float attackPow;

    public void Attack(Character enemy)
    {
        Console.WriteLine(name + " attacks " + enemy.name + $" and does {attackPow} of damage");
        enemy.health -= attackPow;
        Console.WriteLine($"{enemy.name} Health = {enemy.health}");
    }

    protected void death()
    {
        if (health <= 0)
        {
            //Die
        }
    }
}

class Wizard : Character // wizard hereda de character
{
    private float magicDmg;

    public Wizard(string name, int health, float magicDmg)
    {
        this.name = name;
        this.health = health;
        this.magicDmg = magicDmg;
        attackPow = magicDmg;
    }
}

class Swordsman : Character // swordsman hereda de character
{
    private float meeleDmg;

    public Swordsman(string name, int health, float meeleDmg)
    {
        this.name = name;
        this.health = health;
        this.meeleDmg = meeleDmg;
        attackPow = meeleDmg;
    }
}