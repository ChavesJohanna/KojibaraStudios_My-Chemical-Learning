using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CargarCheckpoint : MonoBehaviour, IPointerDownHandler //el script se encuentra en el boton con el mismo nombre del menu de pausa y l apantalla de derrrota
{
    private string nivelActual;

    private void Start()
    {
        nivelActual = SceneManager.GetActiveScene().name; //obtiene el nombre de la escena actual
    }
    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        SceneManager.LoadScene(nivelActual); //recarga la escena
    }

}
