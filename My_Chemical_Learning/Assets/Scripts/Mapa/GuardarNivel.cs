using UnityEngine;
using UnityEngine.SceneManagement;

public static class GuardarNivel
{
    private static string nivelAnterior;

    
    public static void GuardarNivelActual() //guarda el nivel actual antes de pasar a la mesa
    {
        nivelAnterior = SceneManager.GetActiveScene().name;
    }

 
    public static string ObtenerNivelAnterior()  //devuelve el nombre de la escena guardada
    {
        return nivelAnterior;
    }

    public static void CargarNivelAnterior() //recarga el nivel en el que estaba el jugador
    {
        if (!string.IsNullOrEmpty(nivelAnterior)) //si el nivel ni esta vacio recien lo carga
        {
            SceneManager.LoadScene(nivelAnterior);
        }
    }
}
