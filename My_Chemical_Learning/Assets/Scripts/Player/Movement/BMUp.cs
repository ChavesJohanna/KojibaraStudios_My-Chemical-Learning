using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BMUp : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private LayerMask groundLayer;

    private IMove moveType;

    private void Start()
    {
        moveType = new MoveUp(playerRb, groundLayer);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        moveType.Move();

        Debug.Log("boton SALTAR presionado");
    }
}
