using System;

namespace Classes
{
    /*
    Para la clase Items se decidio utilizar una abstracción, en este caso herencia,
    para facilitar la creación de otras clases de items. 
    Comparten atributos en común en general, como un nombre y si son magicos, que todos
    los items tienen.

    SRP: La única responsabilidad de los items comunes (sin contar los que también implementan
    la interfaz IFusionMaterial) es conocerse a sí mismos, cumpliendo con SRP.
    La idea al diseñar la clase fue el disminuir lo más posible su razón de cambio, el
    único motivo por el que cambiarías una clase de items es para modificar su ataque o
    defensa.

    OCP: A su vez, al no existir mayor necesidad de cambiar la clase 
    (todos los items tienen estos dos atributos), se cumple con OCP.
    Esto nos permite expandir la cantidad de Items mediante herencia (incluso de nuevos
    tipos de items con otras clases abstractas) sin necesidad de cambiar el código existente.

    LSP: Si bien no se aplica en esta clase, cuando se requiere un Items por parametro
    se puede reemplazar por cualquier subtipo de Items, ya sea OffensiveItem, DefensiveItem, etc,
    y el funcionamiento sería el mismo.
    */
    public abstract class Items
    {
        public string Name {get; set;}
        public bool Magical {get; set;}
    }
}