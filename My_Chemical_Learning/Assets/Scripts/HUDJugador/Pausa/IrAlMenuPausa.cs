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

        pausa.ReanudarJuego();

        StartCoroutine(EsperarYCargarMenu());
    }

    private IEnumerator EsperarYCargarMenu()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene("MenuPrincipal");
    }
}