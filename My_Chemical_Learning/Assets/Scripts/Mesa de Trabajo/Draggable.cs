using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float _zDepth;
    private ChemElement _miElemento;
    private readonly HashSet<ChemElement> _elementosSuperpuestos = new HashSet<ChemElement>();

    private void Awake()
    {
        _miElemento = GetComponent<ChemElement>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _zDepth = transform.position.z;
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
        if (_miElemento == null) return;

        WorkbenchManager mesa = FindFirstObjectByType<WorkbenchManager>();
        if (mesa != null)
        {
            mesa.EvaluarSoltado(_miElemento, new List<ChemElement>(_elementosSuperpuestos));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ChemElement otro = other.GetComponent<ChemElement>();
        if (otro != null) _elementosSuperpuestos.Add(otro);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ChemElement otro = other.GetComponent<ChemElement>();
        if (otro != null) _elementosSuperpuestos.Remove(otro);
    }

    // Empuja este elemento fuera del collider de "centro", a la distancia indicada
    public void EmpujarFuera(Vector3 centro, float distancia)
    {
        Vector2 direccion = (Vector2)(transform.position - centro);
        if (direccion.sqrMagnitude < 0.0001f)
        {
            direccion = Random.insideUnitCircle.normalized;
        }
        direccion.Normalize();

        Vector3 nuevaPosicion = centro + (Vector3)(direccion * distancia);
        nuevaPosicion.z = transform.position.z;
        transform.position = nuevaPosicion;
    }
}