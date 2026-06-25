using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BUse : MonoBehaviour, IPointerClickHandler
{
    private PAbility player;

    private BShortcut shortcut;


    void Start()
    {
       // ItemPool.Instance.Key("Water");

        player = GameObject.FindWithTag("Player").GetComponent<PAbility>();

        shortcut = GameObject.FindWithTag("Shortcut").GetComponent<BShortcut>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        // ItemPool.Instance.Key("Water");

        if (shortcut.ShortcutActive())
        {
            player.UseAbility();
        }
        
    }

}
