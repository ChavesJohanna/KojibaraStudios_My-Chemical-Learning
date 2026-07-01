using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BUseTable : MonoBehaviour, IPointerClickHandler
{

    private Transform player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (CheckPoint.TryGetPosition(out Vector3 position))
        {
            player.position = position;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Verificamos si hay una mesa activa y no es null
        if (WorkTable.tableInUse != null && WorkTable.tableInUse.IsUsed())
        {
            Debug.Log($"Entrando a la mesa: {WorkTable.tableInUse.name}");

            CheckPoint.Save(player.position);
            SceneManager.LoadScene("Mesa de trabajo");
        }
        else
        {
            Debug.Log("No estás cerca de ninguna mesa para usarla.");
        }
    }

}



