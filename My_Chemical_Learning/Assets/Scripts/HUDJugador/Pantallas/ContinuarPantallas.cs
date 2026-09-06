using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ContinuarPantallas : MonoBehaviour, IPointerDownHandler
{
    private string[] niveles = new string[]
    {
        "Nivel1",
        "Nivel2",
    };

    private string nivelActual; //permitira q el boton conozta el nivel actual  

    private void Start()
    {
        nivelActual = SceneManager.GetActiveScene().name; //obtiene el nombre de la escena actual
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        int indiceActual = System.Array.IndexOf(niveles, nivelActual); //busca el indice donde se encuentra el nivel actual dentro del array

        if (indiceActual >= 0 && indiceActual < niveles.Length - 1) //verifica que exita un siguiente nivel antes de cargarlo
        {
            string siguienteNivel = niveles[indiceActual + 1];

            SceneManager.LoadScene(siguienteNivel); //carga la escena del siguiente nivel
        }
    }
}
