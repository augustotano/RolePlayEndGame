using System;
using System.Collections.Generic;

namespace Classes
{
    /*
    SRP: La única responsabilidad de la clase es la manera en la que sea lee la información del
    escenario. Esto facilita futuras modificaciones.

    Creator: Como ReadEncounters y ReadCharacters son los que obtienen la información necesaria
    como para crear los objetos de tipo IEncounter y CharacterClass, es natural que estos mismos
    sean los que lo crean. A su vez, almacena objetos de este tipo para devolverlos.

    Polimorfismo: Los metodos son polimorficos, lo que permite una implementación distinta en 
    cada clase que lo implemente. Esto permite que se puedan leer distintos tipo de archivos,
    de distintas maneras.
    */
    public interface IScenarioReader
    {
        List<IEncounter> ReadEncounters(string path);
        List<List<CharacterClass>> ReadCharacters(string path);
    }
}