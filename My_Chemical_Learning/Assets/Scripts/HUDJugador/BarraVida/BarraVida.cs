using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Image barraLlena;

    private float vidaMaxima = 100f;
    private float vidaMinima = 25f;

    private float vidaActual = 100f;

    private void Start()
    {
        barraLlena = transform.Find("Completa").GetComponent<Image>();
    }

    public void Disminuir()
    {
        float daño = 10f;

        vidaActual = Mathf.Clamp(vidaActual - daño, vidaMinima, vidaMaxima); //limita la vida para que no se pase

        barraLlena.fillAmount = vidaActual / vidaMaxima; //va borrando la imagen con la vida maxima
    }
}
