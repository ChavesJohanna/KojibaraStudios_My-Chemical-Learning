using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BMenu : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Time.timeScale = 1f; //Linea para descongelar el juego al volver del menu de pausa al principal

            SceneManager.LoadScene("Menu");

            Debug.Log("Volviendo al menu principal");
        });
    }
}
