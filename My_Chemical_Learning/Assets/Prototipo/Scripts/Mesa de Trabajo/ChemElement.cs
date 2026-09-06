using UnityEngine;
using UnityEngine.EventSystems;

public class ChemElement : MonoBehaviour, IPointerDownHandler
{
    public ChemElementType type;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ElementInfoDisplay.Instance != null)
        {
            ElementInfoDisplay.Instance.MostrarInfo(type);
        }
    }
}