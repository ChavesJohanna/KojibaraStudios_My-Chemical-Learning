using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CargarCheckpoint : MonoBehaviour, IPointerDownHandler
{
    private string nivelActual;

    private void Start()
    {
        nivelActual = SceneManager.GetActiveScene().name;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirBoton();

        StartCoroutine(EsperarYRecargarNivel());
    }

    private IEnumerator EsperarYRecargarNivel()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(nivelActual);
    }
}