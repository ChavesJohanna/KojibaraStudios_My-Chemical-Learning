using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IrAlMenuPantallas : MonoBehaviour, IPointerDownHandler
{
    private string menuEscena = "MenuPrincipal";

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirBoton();

        StartCoroutine(EsperarYCargarMenu());
    }

    private IEnumerator EsperarYCargarMenu()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(menuEscena);
    }
}