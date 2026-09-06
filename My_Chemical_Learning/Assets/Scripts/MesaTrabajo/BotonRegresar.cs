using UnityEngine;
using UnityEngine.EventSystems;

public class BotonRegresar : MonoBehaviour, IPointerDownHandler //el script se encuntra en el boton del mismo nombre en la escena de la "Mesa de trabajo"
{
    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        GuardarNivel.CargarNivelAnterior(); //carga el nivel en el que se encontrba el jugador
    }
}
