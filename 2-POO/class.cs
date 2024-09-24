class Apuntador
{
    public string Color { get; set; }
    public string Largo { get; set; }
    public short NumeroBotones { get; set; }
    public bool TieneStickers { get; set; }


}

Apuntador apuntador1 = new Apuntador();
Apuntador apuntador2 = new Apuntador();

apuntador1.Color = "Rojo";
apuntador1.Largo = "15 cm";
apuntador1.NumeroBotones = 2;
apuntador1.TieneStickers = true;

apuntador2.Color = "Azul";
apuntador2.Largo = "10 cm";
apuntador2.NumeroBotones = 1;
apuntador2.TieneStickers = false;