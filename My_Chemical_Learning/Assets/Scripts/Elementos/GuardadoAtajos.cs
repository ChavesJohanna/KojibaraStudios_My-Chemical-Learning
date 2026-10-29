using UnityEngine;
using System.Collections.Generic;

public class GuardadoAtajos : MonoBehaviour
{
    public static GuardadoAtajos Instance { get; private set; }

    private Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();
    private Sprite spriteVacio;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        spriteVacio = Resources.Load<Sprite>("SpritesElementos/item_Vacio");
    }

    public void GuardarSprite(int id, Sprite sprite)
    {
        if (sprite == null || sprite == spriteVacio)
        {
            sprites.Remove(id);
            return;
        }

        sprites[id] = sprite;
    }

    public Sprite ObtenerSprite(int id)
    {
        if (!sprites.ContainsKey(id))
            return spriteVacio;

        return sprites[id];
    }

    // Borra los elementos asignados a los atajos al comenzar otro nivel.
    public void ReiniciarAtajos()
    {
        sprites.Clear();
    }
}