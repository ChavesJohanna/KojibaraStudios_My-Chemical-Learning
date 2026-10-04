using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Espacio : MonoBehaviour, IPointerDownHandler, IBotonInventario //se encuentra en los botones con el mismo nombre
{
    private Inventario inventario;
    private Image imgElemento; //el sprite que tiene el espacio del inventario

    private int indice;

    private void Start()
    {
        inventario = transform.parent.GetComponentInParent<Inventario>();

        imgElemento = GetComponent<Image>();

        indice = transform.GetSiblingIndex(); //obtiene el indice de su posiscion

        imgElemento.sprite = DesbloqueoElementos.Instance.ObtenerSpriteGuardado(indice); //le asinamos el sprite guardado
            
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al presionar el boton
    {
        inventario.IntercambiarSprite(this); //le pasa la imagen al inventario para que haga el intercambio

    }

    public Image ObtenerImagenElemento()
    {
        return imgElemento;
    }
}
