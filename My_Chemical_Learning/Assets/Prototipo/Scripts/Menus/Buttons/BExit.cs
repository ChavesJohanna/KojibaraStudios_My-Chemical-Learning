using UnityEngine;
using UnityEngine.UI;

public class BExit : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Application.Quit();

            Debug.Log("Saliendo del juego");
        });
    }

}
