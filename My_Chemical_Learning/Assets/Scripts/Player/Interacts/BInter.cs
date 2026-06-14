using UnityEngine;
using UnityEngine.EventSystems;

public class BInter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PDetector detPlayer;

    public void OnPointerClick(PointerEventData eventData)
    {
        detPlayer.Detected();
    }
}
