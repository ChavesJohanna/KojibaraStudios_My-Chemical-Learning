using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Rigidbody2D player;

    private IMove moveType;

    private bool isPressed;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        moveType = GetComponent<IMove>();
    }

    private void FixedUpdate()
    {
        if (isPressed) moveType.Move(player);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;

        Debug.Log($"boton de movimiento presionado");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;

        Debug.Log("boton de movimiento soltado");
    }


}
