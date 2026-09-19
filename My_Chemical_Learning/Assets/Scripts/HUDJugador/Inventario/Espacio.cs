using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Espacio : MonoBehaviour, IPointerDownHandler, IBotonInventario //se encuentra en los botones con el mismo nombre
{
    private Inventario inventario;
    private Image imagenElemento; //el sprite que tiene el espacio del inventario

    private void Start()
    {
        inventario = transform.parent.GetComponentInParent<Inventario>();

        imagenElemento = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al presionar el boton
    {
        inventario.IntercambiarSprite(this); //le pasa la imagen al inventario para que haga el intercambio

    }

    public Image ObtenerImagenElemento()
    {
        return imagenElemento;
    }
}
