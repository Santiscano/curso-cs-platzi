class SuperHero {
    public int Id; // public: se puede acceder desde cualquier parte
    protected string Name; // protected: se puede acceder desde la misma clase o clases derivadas
    internal string IdentitySecret; // internal: se puede acceder desde el mismo ensamblado
    private List<SuperPower> SuperPowers; // private: solo se puede acceder desde la misma clase
    file bool CanFly; // protected internal: se puede acceder desde la misma clase, clases derivadas o ensamblados
}