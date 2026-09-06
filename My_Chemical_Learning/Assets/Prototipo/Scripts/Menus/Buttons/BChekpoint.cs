using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BChekpoint : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Time.timeScale = 1f; //Descongelamos el juego 

            string currentSceneName = SceneManager.GetActiveScene().name; //Obtenemos el nombre de la escena actual

            SceneManager.LoadScene(currentSceneName);

            Debug.Log("Reiniciando nivel desde el último checkpoint.");
        });
    }
}
