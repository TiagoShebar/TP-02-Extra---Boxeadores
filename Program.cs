internal class Program
{
    private static void Main(string[] args)
    {
        Boxeador b1 = null;
        Boxeador b2 = null;

        int menu;

        do{
            menu = ingresarInt("Ingrese la opción:\ni. Cargar Datos Boxeador 1\nii. Cargar Datos Boxeador 2\niii. Pelear!\niv. Salir");
            switch(menu){
                case 1:
                    b1 = ObtenerBoxeador();
                break;
                case 2:
                    b2 = ObtenerBoxeador();
                break;
                case 3:
                    if(b1 != null && b2 != null){
                        Pelear(b1, b2);
                    }
                    else{
                        Console.WriteLine("No se puede pelear porque se deben cargar ambos boxeadores");
                        if(b1 == null && b2 == null){
                            Console.WriteLine("Faltan cargar ambos boxeadores");
                        }
                        else if(b1 == null){
                            Console.WriteLine("Falta carga el boxeador 1");
                        }
                        else{
                            Console.WriteLine("Falta carga el boxeador 2");
                        }
                    }
                break;
            }
            if(menu != 4){
                Console.ReadKey();
                Console.Clear();
            }
        }while(menu != 4);
    }

    static string ingresarString(string mensaje){
        Console.WriteLine(mensaje);
        return Console.ReadLine();
    }

    static int ingresarInt(string mensaje){
        int entero;
        Console.WriteLine(mensaje);
        entero = int.Parse(Console.ReadLine());
        while(entero <= 0){
            Console.WriteLine("ERROR. El ingreso debe ser mayor a cero");
            Console.WriteLine(mensaje);
            entero = int.Parse(Console.ReadLine());
        }
        return entero;
    }

    static Boxeador ObtenerBoxeador(){
        string nom = ingresarString("Ingrese el nombre: ");
        string pais = ingresarString("Ingrese el pais: ");
        int peso = ingresarInt("Ingrese el peso: ");
        int pg = ingresarPGYVP("Ingrese la potencia de golpes: ");
        int vp = ingresarPGYVP("Ingrese la velocidad de piernas: ");
        return new Boxeador(nom, pais, peso, pg, vp);
    }

    static int ingresarPGYVP(string mensaje){
        const int MIN = 1;
        const int MAX = 100;
        int ingreso = ingresarInt(mensaje);
        while(ingreso < MIN || ingreso > MAX){
            Console.WriteLine("ERROR. El ingreso debe estar entre el rango " + MIN + "-" + MAX);
        }
        return ingreso;
    }

    static void Pelear(Boxeador b1, Boxeador b2){
        int skillB1 = b1.ObtenerSkill();
        int skillB2 = b2.ObtenerSkill();
        int diferencia;
        string ganador;
        if(skillB1 != skillB2){
            if(skillB1 > skillB2){
                diferencia = skillB1 - skillB2;
                ganador = b1.Nombre;
            }
            else{
                diferencia = skillB2 - skillB1;
                ganador = b2.Nombre;
            }

            if(diferencia >= 30){
                Console.WriteLine("Ganó " + ganador + " por KO");
            }else if(diferencia >= 10 && diferencia < 30){
                Console.WriteLine("Ganó " + ganador + " por puntos en fallo unánime");
            }
            else{
                Console.WriteLine("Ganó " + ganador + " por puntos en fallo dividido");
            }
        }
        else{
            Console.WriteLine("Empate");
        }

    }
    
}