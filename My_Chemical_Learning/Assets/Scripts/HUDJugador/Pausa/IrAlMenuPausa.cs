using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IrAlMenuPausa : MonoBehaviour, IPointerDownHandler
{
    private Pausa pausa;

    private void Start()
    {
        pausa = transform.parent.GetComponentInParent<Pausa>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirBoton();

        StartCoroutine(EsperarYCargarMenu());
    }

    private IEnumerator EsperarYCargarMenu()
    {
        // Espera medio segundo incluso si el juego está pausado.
        yield return new WaitForSecondsRealtime(0.5f);

        // Reanuda el juego antes de cambiar de escena.
        pausa.ReanudarJuego();

        // Carga el menú principal.
        SceneManager.LoadScene("MenuPrincipal");
    }
}