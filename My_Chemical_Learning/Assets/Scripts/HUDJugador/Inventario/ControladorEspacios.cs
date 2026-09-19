using UnityEngine;
using UnityEngine.UI;

public class ControladorEspacios : MonoBehaviour
{
    private Espacio espacioActivo; //primer espacio seleccionado
    private Espacio segundoEspacio;

    private Sprite spriteActivo; //sprite del primer espacio
    private Sprite segundoSprite;

    public void Seleccionar(Espacio espacio, Sprite sprite)
    {
        //Si todavía no hay ningún espacio seleccionado,
        //guardamos el primero
        if (espacioActivo == null)
        {
            espacioActivo = espacio;
            spriteActivo = sprite;

            Debug.Log("Primer espacio seleccionado");
            return;
        }

        //Evita seleccionar dos veces el mismo espacio
        if (espacio == espacioActivo)
            return;

        //Guardamos el segundo espacio
        segundoEspacio = espacio;
        segundoSprite = sprite;

        Intercambiar();
    }

    private void Intercambiar()
    {
        Image imagenPrimera = espacioActivo.GetComponent<Image>();
        Image imagenSegunda = segundoEspacio.GetComponent<Image>();

        if (imagenPrimera == null || imagenSegunda == null)
            return;

        //Intercambio de sprites
        imagenPrimera.sprite = segundoSprite;
        imagenSegunda.sprite = spriteActivo;

        //Limpiamos la selección para comenzar otro intercambio
        espacioActivo = null;
        segundoEspacio = null;

        spriteActivo = null;
        segundoSprite = null;

        Debug.Log("Sprites intercambiados");
    }
}
