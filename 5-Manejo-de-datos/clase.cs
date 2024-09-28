class Animal
{
    // creame 3 medotos
    // 1. Comer
    public abstract void emitirSonido();
}

class Perro : Animal
{
    public void emitirSonido()
    {
        Console.WriteLine("Ladrar");
    }
}

class Gato : Animal
{
    public void emitirSonido()
    {
        Console.WriteLine("Maullar");
    }
}

class Pajaro : Animal
{
    public void emitirSonido()
    {
        Console.WriteLine("Pio pio");
    }
}