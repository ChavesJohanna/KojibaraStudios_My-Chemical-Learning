using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BUse : MonoBehaviour, IPointerClickHandler
{
    private PAbility pAbil;
    private PAnimation pAnim; 

    private BShortcut shortcut;

    // Tiempo necesario entre clics
    private float cooldownTime = 1f;
    // Momento en el que se permitirá el próximo clic
    private float nextClickTime = 0f;

    void Start()
    {

        pAbil = GameObject.FindWithTag("Player").GetComponent<PAbility>();
        pAnim = GameObject.FindWithTag("Player").GetComponent<PAnimation>();

        shortcut = GameObject.FindWithTag("Shortcut").GetComponent<BShortcut>();

    }


    public void OnPointerClick(PointerEventData eventData)
    {

        /* if (shortcut.ShortcutActive())
         {
             pAbil.UseAbility();
             pAnim.ShootAnim();
         }
         */

        // Verificamos si el shortcut está activo Y si ha pasado el tiempo necesario
        if (shortcut.ShortcutActive() && Time.time >= nextClickTime)
        {
            pAbil.UseAbility();
            pAnim.ShootAnim();

            // Actualizamos el tiempo para el próximo clic permitido
            nextClickTime = Time.time + cooldownTime;
        }
    }

}
