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
            SceneManager.LoadScene("Menu");

            Debug.Log("Volviendo al menu principal");
        });
    }
}
