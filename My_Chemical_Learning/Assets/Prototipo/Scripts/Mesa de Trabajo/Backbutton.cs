using UnityEngine;
using UnityEngine.SceneManagement;

public class Backbutton : MonoBehaviour
{
    public void GoBack()//carga el nuevo nivel 1
    {
        SceneManager.LoadScene("Nivel1"); //carga la scena nivel1 
    }
}
