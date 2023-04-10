class Boxeador{
    public string Nombre{get;private set;}
    public string Pais{get;private set;}
    public int Peso{get;private set;}
    public int PotenciaGolpes{get;private set;}
    public int VelocidadPiernas{get;private set;}

    public Boxeador(string nom, string pais, int peso, int pg, int vp){
        Nombre = nom;
        Pais = pais;
        Peso = peso;
        PotenciaGolpes = pg;
        VelocidadPiernas = vp;
    }

    public int ObtenerSkill(){
        Random r = new Random();
        return Convert.ToInt32(VelocidadPiernas*0.6+PotenciaGolpes*0.8+r.Next(1,11));
    }
}