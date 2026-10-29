using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonRegresar : MonoBehaviour
{
    private Button boton;

    private void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(Regresar);
    }

    private void Regresar()
    {
        // Evita pulsaciones repetidas mientras espera.
        boton.interactable = false;

        // Reproduce el sonido del botón.
        AudioManager.Instance.ReproducirBoton();

        // Espera a que el sonido se escuche antes de cambiar de escena.
        StartCoroutine(EsperarYRegresar());
    }

    private IEnumerator EsperarYRegresar()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        string nivelAnterior = GuardarNivel.ObtenerNivelAnterior();
        SceneManager.LoadScene(nivelAnterior);
    }
}