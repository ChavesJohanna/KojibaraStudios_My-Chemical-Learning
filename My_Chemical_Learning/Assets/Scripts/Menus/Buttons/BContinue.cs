using UnityEngine;
using UnityEngine.UI;

public class BContinue : MonoBehaviour
{
    private GameObject panel;


    private Button button;

    private void Start()
    {
        panel = transform.parent.gameObject; //Tomamos el panel padre del botón

        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Time.timeScale = 1f; // Reanuda el tiempo normal
            panel.SetActive(false);
            Debug.Log("Juego reanudado");
        });
    }

}
