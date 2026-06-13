using UnityEngine;
using UnityEngine.UI;

public class BMUp : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;

    private Button button;
    private IMove moveCommand;

    private void Awake()
    {
        button = GetComponent<Button>();

        moveCommand = new MoveUp(playerRb);

        button.onClick.AddListener(() =>
        {
            moveCommand.Execute();
        });
    }
}
