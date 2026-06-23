using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BUItem : MonoBehaviour, IPointerClickHandler
{
    private IUseItem[] pUse;

    private void Start()
    {
        pUse = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
        .OfType<IUseItem>().ToArray();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < pUse.Length; i++)
        {
            pUse[i].UseItem();

            Debug.Log("ejecutando useItem");
        }
    }
}
