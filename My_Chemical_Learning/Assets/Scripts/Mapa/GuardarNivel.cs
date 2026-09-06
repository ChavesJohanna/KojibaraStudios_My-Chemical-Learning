using UnityEngine;
using UnityEngine.SceneManagement;

public static class GuardarNivel
{
    private static string nivelAnterior;

    
    public static void GuardarNivelActual(string nivel) //guarda el nivel actual antes de pasar a la mesa
    {

        if (nivelAnterior == nivel) //si ya esta guardado y es el mismo, no lo sobrescribe
            return;
        

        nivelAnterior = nivel;
    }

 
    public static string ObtenerNivelAnterior()  //devuelve el nombre de la escena guardada
    {
        return nivelAnterior;
    }

}
