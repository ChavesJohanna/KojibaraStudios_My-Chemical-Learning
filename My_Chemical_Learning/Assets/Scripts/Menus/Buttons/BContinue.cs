using UnityEngine;
using UnityEngine.UI;

public class BContinue : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Time.timeScale = 1f; // Reanuda el tiempo normal
            Debug.Log("Juego reanudado");
        });
    }

}
