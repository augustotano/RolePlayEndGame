using System;

namespace Classes
{
    /*
    Para los items combinados decidimos crear una interfaz IFusionMaterial. 
    Esta interfaz sirve para agruparlos, además de verificar que tengan los metodos adecuados
    para funcionar.
    El metodo Fuse() devuelve el item fusionado y recibe como parametro el otro item material necesario.
    El metodo Check() devuelve al IFusionMaterial pero como Items. Esto se utiliza en distintos chequeos
    a lo largo del programa.
    */
    public interface IFusionMaterial
    {
        Items Fuse(IFusionMaterial item);
        Items Check();
        
    }
}