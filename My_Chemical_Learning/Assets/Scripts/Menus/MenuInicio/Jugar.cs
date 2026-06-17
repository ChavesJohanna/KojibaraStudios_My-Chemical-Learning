using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    public void JugarJuego()
    {
        Debug.Log("Iniciando el juego...");
        SceneManager.LoadScene("SampleScene"); // Cambiar el nombre segun la escena, Ej: Nivel1, Nivel2, etc.
    }
}
