using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Atajo : MonoBehaviour, IPointerDownHandler //se ecuentra en los botones con el miesmo nombre
{
    private ControladorAtajos controlador; //componente del padre de este objeto
    private GameObject activado; //objeto hijo con la imagen del atajo "Activado"

    private Image imagenElemento; //usara el nombre del sprite para asignarlo y que el jugador lo dispare

    private void Start()
    {
        controlador = GetComponentInParent<ControladorAtajos>();

        if (controlador == null) 
            return;
            

        activado = transform.Find("Activado")?.gameObject;
        imagenElemento = transform.Find("Elemento")?.GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al presionar el boton
    {
        if (controlador == null) 
            return;
          

        controlador.Seleccionar(this);

        
    }

    public void Activar()
    {
        if (activado == null) 
            return;
            
        activado.SetActive(true);

    }

    public void Desactivar()
    {
        if (activado == null) 
            return;
            

        activado.SetActive(false);
    }

    public string ObtenerNombreElemento()
    {
        if (imagenElemento == null) //si no exite la imagen retorna null
            return null;

        if (imagenElemento.sprite == null) 
            return null;

        string nombreElemento = imagenElemento.sprite.name;//nombre del sprite en el componente Image que se encutra el en hijo de este objeto

        nombreElemento = nombreElemento.Replace("item_", ""); //quita "item_" del nombre del sprite

        return nombreElemento;
    }
}
