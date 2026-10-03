using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteElemento : MonoBehaviour//, IPointerDownHandler //se encuentra tanto en los atajos como los espacios del inventario y sirve para mantener los sprites en su lugar luego de pasar de nivel o cargar un checkpoint
{
    private Image imagenElemento;
    private int indice;

    private void Start()
    {
        imagenElemento = GetComponent<Image>();

        indice = transform.GetSiblingIndex(); //obtiene el indice de su posiscion

        imagenElemento.sprite =
            ManagerElementos.Instance.ObtenerSpriteGuardado(indice);
    }

}
