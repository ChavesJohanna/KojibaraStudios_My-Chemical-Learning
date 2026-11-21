using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour
{
    private GameObject botonMenu;

    private Image vega;
    private Image imgFinal;
    private Image imgBoton;

    private float duracionFade = 2f;
    private float tiempoCreditos = 45f; //el tiempo que tardan en mostrarse todos los creditos

    private void Start()
    {
        botonMenu = transform.Find("BotonIrAlMenu").gameObject;
        imgBoton = botonMenu.GetComponent<Image>();

        vega = transform.Find("VegaCreditos").GetComponent<Image>();
        imgFinal = transform.Find("ImagenFinal").GetComponent<Image>();

        botonMenu.SetActive(false);

        Color colorVega = vega.color; //hacemos que vega quede visible
        colorVega.a = 1f;
        vega.color = colorVega;

        Color colorFinal = imgFinal.color; //hacemo que la img final este invisible
        colorFinal.a = 0f;
        imgFinal.color = colorFinal;

        Color colorBoton = imgBoton.color; //hacemo que la img final este invisible
        colorBoton.a = 0f;
        imgBoton.color = colorBoton;

        StartCoroutine(PantallaFinal());

    }

    private IEnumerator PantallaFinal()
    {
        yield return new WaitForSeconds(tiempoCreditos);

        yield return StartCoroutine(CambiarAlpha(vega, 1f, 0f)); // Fade Out de Vega

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(CambiarAlpha(imgFinal, 0f, 1f));// Fade In de la imagen final

        botonMenu.SetActive(true);// Activar botón del menú

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(CambiarAlpha(imgBoton, 0f, 1f));// Fade In del boton
    }

    private IEnumerator CambiarAlpha(Image imagen, float inicio, float final) //pa hacer una tipo animacion de fade
    {
        float tiempo = 0f;

        Color color = imagen.color;
        color.a = inicio;
        imagen.color = color;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;

            color.a = Mathf.Lerp(inicio, final, tiempo / duracionFade);
            imagen.color = color;

            yield return null;
        }

        color.a = final;
        imagen.color = color;
    }
}
