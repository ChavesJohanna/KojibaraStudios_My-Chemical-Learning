using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour//se encuentra en el objeto con el mismo nombre
{
    private IBotonInventario primerBoton;

    private bool cambioPermitido = false; //servira para que solo se pueda hacer cambios cuando el panel de inventario este activo
   
    public void IntercambiarSprite(IBotonInventario boton)
    {
        if (!cambioPermitido) //si el panel se cerro evita que se continue
            return;

        if (primerBoton == null)
        {
            primerBoton = boton;
            return;
        }

        if (!PuedeIntercambiar(primerBoton, boton))
        {
            primerBoton = null;
            return;
        }

        Image primeraImagen = primerBoton.ObtenerImagenElemento();
        Image segundaImagen = boton.ObtenerImagenElemento();

        if (primeraImagen == null || segundaImagen == null)
        {
            primerBoton = null;
            return;
        }

        Sprite temporal = primeraImagen.sprite;

        primeraImagen.sprite = segundaImagen.sprite;
        segundaImagen.sprite = temporal;


        
        if (primerBoton is Atajo atajo1) //si el primer boton es un atajo le pasa el nuevo nombre del sprite al Pool
            ActualizarAtajo(atajo1);

        if (boton is Atajo atajo2) //igual que el anterios pero si es el segundo botn tocado
            ActualizarAtajo(atajo2);

        primerBoton = null;
    }

    private bool PuedeIntercambiar(IBotonInventario boton1, IBotonInventario boton2)
    {
        if (boton1 is Atajo && boton2 is Atajo) //evita que se intercambien los sprites entre atajos
            return false;

        return true;
    }

    private void ActualizarAtajo(Atajo atajo) //actualiza el nombre que le pasa al pool cuando ocurre un intercambio
    {
        string nombreElemento = atajo.ObtenerNombreElemento();

        if (nombreElemento == null)
            return;

        if (nombreElemento == "")
            return;

        PoolElementos.Instance.ActivarElemento(nombreElemento);
    }

    public void PanelAbierto(bool abierto)
    {
        this.cambioPermitido = abierto;

        if (!abierto) //una vez esta cerrado se limpa las selecciones del inventario para evitar que se guarden las anetriores
            primerBoton = null;
    }
}
