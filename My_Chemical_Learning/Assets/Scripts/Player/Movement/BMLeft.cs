using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BMLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rigidbody2D playerRb;

    private IMove moveType;

    private bool isPressed;

    private void Start()
    {
        moveType = new MoveLeft(playerRb);
    }

    private void FixedUpdate()
    {
        if (isPressed) moveType.Move();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;

        Debug.Log("boton " + "IZQUIERDA" + "  presionado");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;

        Debug.Log("boton " + "IZQUIERDA" + " soltado");
    }
}