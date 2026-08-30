using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    public void VolverAlMenu()
    {
        Debug.Log("Volviendo al menú principal...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Titulo"); //Cargamos la escena del titulo
    }
}

