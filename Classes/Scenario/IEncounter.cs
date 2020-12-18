using System;
using System.Collections.Generic;

namespace Classes
{
    /*
    La interfaz IEncounter permite la creación de futuros encuentros con distintas reglas,
    que igualmente funcionarian en el programa original sin modificar código alguno.

    SRP: La única razón de cambio de un Encounter es la manera en la que se juega (PlayEncounter).
    Esto evita futuros problemas al modificar el código.
    */
    public interface IEncounter
    {
        List<List<CharacterClass>> PlayEncounter();
    } 
}