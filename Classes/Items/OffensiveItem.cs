using System;

namespace Classes
{
    /*
    Una sub-clase de Items son los items ofensivos, que tienen unicamente valor de ataque,
    por lo que se decidió volver a utilizar herencia para que todos los objetos
    basados en esta clase tengan acceso a ese atributo.

    SRP: La única responsabilidad de los items comunes (sin contar los que también implementan
    la interfaz IFusionMaterial) es conocerse a sí mismos, cumpliendo con SRP.
    La idea al diseñar la clase fue el disminuir lo más posible su razón de cambio, el
    único motivo por el que cambiarías una clase de items es para modificar su ataque o
    defensa.

    Más información en la clase base.
    */
    public abstract class OffensiveItem : Items
    {
        public int AttackPower {get; set;} 
    }
}