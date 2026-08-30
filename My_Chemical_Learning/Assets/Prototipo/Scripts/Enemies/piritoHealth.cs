using UnityEngine;

public class piritoHealth : MonoBehaviour
{
    private int hits = 0;

    public void TakeHit()
    {
        hits++;

        if (hits >= 2)
        {
            Destroy(gameObject);
        }
    }
}