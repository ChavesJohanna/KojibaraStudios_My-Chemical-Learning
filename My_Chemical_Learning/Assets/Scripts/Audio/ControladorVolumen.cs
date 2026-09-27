using UnityEngine;
using UnityEngine.UI;

public class ControladorVolumen : MonoBehaviour
{
    private Slider sliderMusica;
    private Slider sliderSFX;

    private void Start()
    {
        sliderMusica = BuscarSlider("SliderMusica");
        sliderSFX = BuscarSlider("SliderSFX");

        if (sliderMusica == null || sliderSFX == null)
        {
            Debug.LogError("No se encontraron los sliders de volumen.");
            return;
        }

        sliderMusica.value = AudioManager.Instance.ObtenerVolumenMusica();
        sliderSFX.value = AudioManager.Instance.ObtenerVolumenSFX();

        sliderMusica.onValueChanged.AddListener(
            AudioManager.Instance.CambiarVolumenMusica
        );

        sliderSFX.onValueChanged.AddListener(
            AudioManager.Instance.CambiarVolumenSFX
        );
    }

    private Slider BuscarSlider(string nombre)
    {
        Slider[] sliders = GetComponentsInChildren<Slider>(true);

        foreach (Slider slider in sliders)
        {
            if (slider.name == nombre)
            {
                return slider;
            }
        }

        return null;
    }

    private void OnDestroy()
    {
        if (AudioManager.Instance == null)
            return;

        if (sliderMusica != null)
        {
            sliderMusica.onValueChanged.RemoveListener(
                AudioManager.Instance.CambiarVolumenMusica
            );
        }

        if (sliderSFX != null)
        {
            sliderSFX.onValueChanged.RemoveListener(
                AudioManager.Instance.CambiarVolumenSFX
            );
        }
    }
}