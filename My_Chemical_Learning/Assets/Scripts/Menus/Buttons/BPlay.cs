using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BPlay : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level_1");

            Debug.Log("Entrando al nivel 1");
        });
    }

}
