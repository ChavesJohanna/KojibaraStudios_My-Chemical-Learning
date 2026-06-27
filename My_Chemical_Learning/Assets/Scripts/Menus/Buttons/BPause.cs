using UnityEngine;
using UnityEngine.UI;

public class BPause : MonoBehaviour
{
    private GameObject panel;

    private Button button;

    private void Start()
    {
        Transform parent = transform.parent.gameObject.transform;
        panel = parent.Find("PPanel").gameObject;

        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            panel.SetActive(true);

            Time.timeScale = 0f; // Detiene el tiempo del juego
            Debug.Log("Juego pausado");
        });
    }

}
