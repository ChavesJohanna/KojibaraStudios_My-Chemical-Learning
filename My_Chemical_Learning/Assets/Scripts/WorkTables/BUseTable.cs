using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BUseTable : MonoBehaviour, IPointerClickHandler
{
    private WorkTable[] tables;

    private void Start()
    {
        GameObject[] workTables = GameObject.FindGameObjectsWithTag("WorkTable");

        tables = new WorkTable[workTables.Length];

        for (int i = 0; i < workTables.Length; i++)
        {
            tables[i] = workTables[i].GetComponent<WorkTable>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (WorkTable table in tables)
        {
            if (!table.IsUsed())
                continue;

            Debug.Log($"Entrando a la mesa: {table.name}");

            // SceneManager.LoadScene(...);

            return;
        }

        Debug.Log("No hay ninguna mesa en uso.");
    }


}



