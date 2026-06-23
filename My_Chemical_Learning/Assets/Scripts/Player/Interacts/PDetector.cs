using UnityEngine;

public class PDetector : MonoBehaviour // se encarga de detectar las colisiones
{
    private IInteract currentObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentObj = other.GetComponent<IInteract>();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IInteract>() == currentObj)
            currentObj = null;

    }

    public void Detected()
    {
        currentObj?.Interact();

    }
}
