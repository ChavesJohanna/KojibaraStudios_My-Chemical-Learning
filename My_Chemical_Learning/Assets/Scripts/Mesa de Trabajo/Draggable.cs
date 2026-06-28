using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float _zDepth;
    private Vector3 _posicionOriginal;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _zDepth = transform.position.z;
        _posicionOriginal = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Camera.main == null) return;

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPoint.z = _zDepth;
        transform.position = worldPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Nada acá: la combinación se evalúa por OnTriggerEnter2D más abajo
    }

    public void VolverAPosicionOriginal()
    {
        transform.position = _posicionOriginal;
    }

    // Requiere que el Collider2D del frasco esté marcado como "Is Trigger"
    private void OnTriggerEnter2D(Collider2D other)
    {
        ChemElement miElemento = GetComponent<ChemElement>();
        WorkbenchManager mesa = FindFirstObjectByType<WorkbenchManager>();

        if (miElemento != null && mesa != null)
        {
            mesa.RegistrarElemento(miElemento);
        }
    }
}