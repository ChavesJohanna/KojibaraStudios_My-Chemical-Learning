using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Atajo : MonoBehaviour, IPointerDownHandler, IBotonInventario //se ecuentra en los botones con el miesmo nombre
{
    private ControladorAtajos controlador; //componente del padre de este objeto
    private GameObject imagenActivado; //objeto hijo con la imagen del atajo "Activado"

    private Image imagenElemento; //usara el nombre del sprite para asignarlo y que el jugador lo dispare

    private Inventario inventario;

    private void Start()
    {
        controlador = GetComponentInParent<ControladorAtajos>();

        if (controlador == null) 
            return;
            

        imagenActivado = transform.Find("Activado")?.gameObject;
        imagenElemento = transform.Find("Elemento")?.GetComponent<Image>();

        inventario = transform.parent.GetComponentInParent<Inventario>();
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al presionar el boton
    {
        if (controlador == null) 
            return;

        controlador.Seleccionar(this);

        inventario.IntercambiarSprite(this); //le pasa la imagen al inventario para que haga el intercambio
    }

    public void Activar()
    {
        if (imagenActivado == null)
            return;

        imagenActivado.SetActive(true);
    }
    public void Desactivar()
    {
        if (imagenActivado == null)
            return;

        imagenActivado.SetActive(false);
    }

    public string ObtenerNombreElemento()
    {
        if (imagenElemento == null) //si no exite la imagen retorna null
            return null;

        if (imagenElemento.sprite == null) 
            return null;

        string nombreElemento = imagenElemento.sprite.name;//nombre del sprite en el componente Image que se encutra el en hijo de este objeto

        nombreElemento = nombreElemento.Replace("item_", ""); //quita "item_" del nombre del sprite

        return nombreElemento;
    }

    public Image ObtenerImagenElemento()
    {
        return imagenElemento;
    }
}
