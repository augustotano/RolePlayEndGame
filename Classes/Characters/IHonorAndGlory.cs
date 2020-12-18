using System;

namespace Classes
{
    /*
    Polimorfismo: Tanto los metodos Register como ShowRegistres son polimorficos, con una implementación
    diferente en cada objeto que implementa el tipo. Esto permite que, siempre que se llame a uno
    de estos metodos, a pesar de tener una diferente implementación, el programa igualmente funciona.

    SRP: La única razon de cambio para cualquier objeto de la interfaz es un cambio en como
    se registran los datos. Gracias a esto, cualquier objeto que la implemente puede ser editado
    sin influir en el funcionamiento final.

    El usar una interfaz también permite que, en un futuro, si se agregaran distintas clases,
    puedan tener un distinto metodo de registro, sin afectar el funcionamiento del programa.
    */
    public interface IHonorAndGlory
    {
        void Register(string data = "");
        string ShowRegistres();
    }
}