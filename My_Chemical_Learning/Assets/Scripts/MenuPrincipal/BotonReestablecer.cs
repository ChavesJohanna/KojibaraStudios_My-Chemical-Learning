using UnityEngine;
using UnityEngine.UI;

public class BotonReestablecer : MonoBehaviour
{
    private Button boton;

    private Slider sliderMusica;
    private Slider sliderSFX;

    private void Start()
    {
        boton = GetComponent<Button>();

        sliderMusica = transform.parent.Find("SliderMusica").GetComponent<Slider>();
        sliderSFX = transform.parent.Find("SliderSFX").GetComponent<Slider>();

        boton.onClick.AddListener(Reestablecer);
    }

    private void Reestablecer()
    {
        AudioManager.Instance.ReproducirBoton();

        sliderMusica.value = 1f;
        sliderSFX.value = 1f;
    }
}