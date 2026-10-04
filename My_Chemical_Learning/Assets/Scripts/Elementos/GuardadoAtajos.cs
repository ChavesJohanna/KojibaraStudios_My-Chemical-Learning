using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuardadoAtajos : MonoBehaviour//se encarga de guardar los prites de los atajos al pasar de nivel o cargar un checkpoint
{
    public static GuardadoAtajos Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();

    private Sprite spriteVacio;


    private void Start()
    {
        spriteVacio = Resources.Load<Sprite>("SpritesElementos/item_Vacio");
    }
    public void GuardarSprite(int id, Sprite sprite)
    {
        if (sprite == null)
            return;

        sprites[id] = sprite;
    }

    public Sprite ObtenerSprite(int id)
    {
        if (!sprites.ContainsKey(id))
            return spriteVacio;

        return sprites[id];
    }
}
