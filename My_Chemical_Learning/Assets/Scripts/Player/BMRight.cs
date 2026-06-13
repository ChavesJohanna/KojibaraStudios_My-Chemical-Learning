using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BMRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rigidbody2D playerRb;

    private Button button;
    private IMove moveCommand;

    private bool isPressed;

    private void Awake()
    {
        button = GetComponent<Button>();

        moveCommand = new MoveRight(playerRb);

    }
    private void FixedUpdate()
    {
        if (isPressed)
        {
            moveCommand.Execute();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;

        Debug.Log("boton presionado");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;

        Debug.Log("boton soltado");
    }
}
