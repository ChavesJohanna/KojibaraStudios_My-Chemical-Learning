using System.Collections;
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

    private string nivelActual;

    private void Start()
    {
        nivelActual = SceneManager.GetActiveScene().name;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirBoton();

        GuardarPartida.ResetearDatos();

        int indiceActual = System.Array.IndexOf(niveles, nivelActual);

        if (indiceActual >= 0 && indiceActual < niveles.Length - 1)
        {
            string siguienteNivel = niveles[indiceActual + 1];

            StartCoroutine(EsperarYCargarNivel(siguienteNivel));
        }
    }

    private IEnumerator EsperarYCargarNivel(string siguienteNivel)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(siguienteNivel);
    }
}