using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPause : MonoBehaviour
{
    private GameObject panel;

    private Button button;

    private PauseMenu pauseMenu;

    private void Start()
    {
        Transform parent = transform.parent.gameObject.transform;
        panel = parent.Find("PPanel").gameObject;

        pauseMenu = GameObject.FindGameObjectWithTag("HUD").GetComponent<PauseMenu>();

        button = GetComponent<Button>();


        button.onClick.AddListener(() =>
        {

            panel.SetActive(true);

            pauseMenu.DesactiveHUD();

            Time.timeScale = 0f; // Detiene el tiempo del juego
            Debug.Log("Juego pausado");

        });
    }

}
