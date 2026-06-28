using System.Transactions;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    private bool isUsed;

    private GameObject sign;
 
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
        }
    }

    public bool IsUsed()
    {
        return isUsed;
    }
}
