using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IrAlMenuPantallas : MonoBehaviour, IPointerDownHandler
{
    private string menuEscena = "MenuPrincipal";

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirBoton();
        SceneManager.LoadScene(menuEscena); //carga el menu
    }
}
