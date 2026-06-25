using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BUse : MonoBehaviour, IPointerClickHandler
{
    private PAbility pAbil;
    private PAnimation pAnim; 

    private BShortcut shortcut;

    void Start()
    {

        pAbil = GameObject.FindWithTag("Player").GetComponent<PAbility>();
        pAnim = GameObject.FindWithTag("Player").GetComponent<PAnimation>();

        shortcut = GameObject.FindWithTag("Shortcut").GetComponent<BShortcut>();

    }


    public void OnPointerClick(PointerEventData eventData)
    {

        if (shortcut.ShortcutActive())
        {
            pAbil.UseAbility();
            pAnim.ShootAnim();
        }
        
    }

}
