using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private List<GameObject> hud;

    private void Start()
    {
        Transform parent = transform.parent.transform;

        hud = new List<GameObject>();

        hud.Add(parent.Find("MoveControls").gameObject);
        hud.Add(parent.Find("InventaryControls").gameObject);
        hud.Add(parent.Find("LifeBar").gameObject);
        hud.Add(parent.Find("UseWorkTable").gameObject);
    }

    public void ActiveHUD()
    {
        foreach (GameObject obj in hud)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    public void DesactiveHUD()
    {
        foreach (GameObject obj in hud)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

 
}
