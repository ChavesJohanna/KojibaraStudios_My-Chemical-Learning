using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CargarCheckpointPausa : MonoBehaviour, IPointerDownHandler //el script se encuentra en el boton con el mismo nombre del menu de pausa y l apantalla de derrrota
{
    private Pausa pausa; //componente del objeto con el msmo nombre
    private string nivelActual;

    private void Start()
    {
        pausa = transform.parent.GetComponentInParent<Pausa>(); //obtiene el componente que se encuentra en "Pausa"

        nivelActual = SceneManager.GetActiveScene().name; //obtiene el nombre de la escena actual
    }
    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        pausa.AbrirPanel(false); //desactiva la pausa y el panel

        SceneManager.LoadScene(nivelActual); //recarga la escena
    }

}
