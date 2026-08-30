using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BPlay : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            StartCoroutine(LoadLevel());
        });
    }

    IEnumerator LoadLevel()
    {
        Debug.Log("Entrando al nivel 1");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Level_1");
    }
}