using System;
using System.Collections.Generic;

namespace Classes
{
    /*
    SRP: La única razón de cambio de objetos que implementen esta clase es la forma en la manera
    en la que se imprime, por lo que se evita complicaciones a la hora de modificar el código.

    Polimorfismo: El metodo Print() puede tener una implementación distinta en cada objeto que lo
    implementa.

    LSP: Cualquier tipo de printer funciona cuando se llama a un IPrinter. Gracias a esto es que
    se puede implementar distintos tipos de impresora sin modificar el codigo de Scenario.

    Extensible: Pueden crearse multiples tipos de impresoras a través de esta interfaz.
    */
    public interface IPrinter
    {
        void Print(List<string> txt);
    }
}