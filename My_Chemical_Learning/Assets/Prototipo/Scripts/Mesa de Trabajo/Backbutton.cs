using UnityEngine;
using UnityEngine.SceneManagement;

public class Backbutton : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Level_1"); //carga la scena nivel1 
    }
}
