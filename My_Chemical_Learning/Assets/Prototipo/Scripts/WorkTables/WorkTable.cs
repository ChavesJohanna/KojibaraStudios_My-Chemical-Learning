using System.Transactions;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    private bool isUsed;

    private GameObject sign;

    public static WorkTable tableInUse; // Referencia a la mesa donde está el player

    private void Start()
    {
        sign = transform.Find("Sign").gameObject;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sign.SetActive(true);
            isUsed = true;
            tableInUse = this;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isUsed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sign.SetActive(false);
            isUsed = false;
            tableInUse = null;
        }
    }

    public bool IsUsed()
    {
        return isUsed;
    }
}
