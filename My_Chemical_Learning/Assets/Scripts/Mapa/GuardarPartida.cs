using UnityEngine;

public static class GuardarPartida
{
    private static Vector3 posicion;
    private static float vida;

    private static bool hayDatosGuardados = false; 

    public static void GuardarDatos(Vector3 nuevaPosicion, float nuevaVida) 
    { 
        posicion = nuevaPosicion;
        vida = nuevaVida; 
        hayDatosGuardados = true; 
    } 

    public static void RecuperarDatos(out Vector3 posicionGuardada, out float vidaGuardada) 
    { 
        posicionGuardada = posicion;
        vidaGuardada = vida; 
    }

    public static bool HayDatosGuardados() 
    { 
        return hayDatosGuardados; 
    } 

    public static void ResetearDatos() 
    { 
        posicion = Vector3.zero; 

        vida = 100f; //regresar la vida a 100

        hayDatosGuardados = false; 
    }
}
