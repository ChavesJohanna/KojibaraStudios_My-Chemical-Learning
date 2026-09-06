using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BCheckPoint : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Time.timeScale = 1f; // Reanuda el tiempo normal

            SceneManager.LoadScene("Level_1");
        });
    }
}
