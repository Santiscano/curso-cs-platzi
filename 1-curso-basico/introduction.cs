// See https://aka.ms/new-console-template for more information
int ladoA;
int ladoB;
int resultado;

Console.WriteLine("Digite o valor do lado A:");
ladoA = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor do lado B:");
ladoB = Convert.ToInt32(Console.ReadLine());


resultado = ladoA * ladoB;
Console.WriteLine("El resultado es: " + resultado);

var otroA = Convert.ToInt32(Console.ReadLine());
var otroB = Convert.ToInt32(Console.ReadLine());

var otroResultado = otroA * otroB;
Console.WriteLine("El resultado es: " + otroResultado);

const double SiempreSeEscribenAsi = 200.0d;

ladoA++;
ladoB--; // ladoB = ladoB - 1;




// piedra papel o tijeras
Console.WriteLine("Piedra papel o tijeras UwU!");
bool juego = true;
int jugador = 0;
Random rdn = new Random();
int oponente = 0;
int maquina = 0;
int usuario = 0;
int empate = 0;
string[] opciones = { "NA", "La maquina elijio Piedra", "La maquina elijio Papel", "La maquina elijio tijeras" };
while (juego == true)
{
    oponente = rdn.Next(1, 3);
    Console.WriteLine("1 Elije Piedra\n2 Elije papel\n3 Elije tijeras");
    jugador = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(opciones[oponente]);
    if (jugador == oponente)
    {
        Console.WriteLine("Juego empatado!!");
        empate++;
    }
    else
    {
        switch (jugador)
        {
            case 1: //jugador juega piedra
                if (oponente == 2)
                {
                    Console.WriteLine("La maquina GANA");
                    maquina++;
                }
                else
                {
                    Console.WriteLine("El usuario GANA");
                    usuario++;
                }
                break;
            case 2://jugador juega papel
                if (oponente == 3)
                {
                    Console.WriteLine("La maquina GANA");
                    maquina++;
                }
                else
                {
                    Console.WriteLine("El usuario GANA");
                    usuario++;
                }
                break;
            case 3://Jugador juega tijeras
                if (oponente == 1)
                {
                    Console.WriteLine("La maquina GANA");
                    maquina++;
                }
                else
                {
                    Console.WriteLine("El usuario GANA");
                    usuario++;
                }
                break;
        }
    }
    Console.WriteLine("Si desea continuar presione enter \nSi desea salir presione 0");
    if (Console.ReadLine() == "0")
    {
        juego = false;
    }

}
Console.WriteLine("Total de Juegos gandos");
Console.WriteLine($"El Usuario Gano: {usuario} juegos");
Console.WriteLine($"La Maquina Gano: {maquina} juegos");
Console.WriteLine($"Se empataron: {empate} juegos");