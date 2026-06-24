using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BUse : MonoBehaviour, IPointerClickHandler
{
    private PAbility player;

    void Start()
    {
        ItemPool.Instance.Key("Water");

        player = GameObject.FindWithTag("Player").GetComponent<PAbility>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPool.Instance.Key("Water");

        player.UseAbility();
    }

}
