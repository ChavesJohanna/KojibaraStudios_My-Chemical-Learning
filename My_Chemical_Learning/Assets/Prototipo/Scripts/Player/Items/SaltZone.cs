using UnityEngine;

public class SaltZone : MonoBehaviour
{
    public bool IsOccupied { get; private set; }

    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    public void SetOccupied(bool state)
    {
        IsOccupied = state;

        col.isTrigger = !state; // markamos la zona para que se pueda caminar sobre ella
    }
}
