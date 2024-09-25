public Persona {
    private string nombre = "sin nombre"; // se pueden asignar por defecto
    private int edad;
    private string genero;

    public Persona(string nombre, int edad, string genero) {
        this.nombre = nombre;
        this.edad = edad;
        this.genero = genero;
    }
}