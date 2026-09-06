using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float _zDepth;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _zDepth = transform.position.z;
        Debug.Log("Begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        // convertir la posición de pantalla (mouse/touch) a una posicion en el mundo del juego
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPoint.z = _zDepth;
        transform.position = worldPoint;

        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
    }
}