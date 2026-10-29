using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private IBotonInventario primerBoton;
    private bool cambioPermitido = false;

    public void IntercambiarSprite(IBotonInventario boton)
    {
        if (!cambioPermitido || boton == null)
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

        // Intercambia los sprites de los dos espacios seleccionados.
        Sprite temporal = primeraImagen.sprite;
        primeraImagen.sprite = segundaImagen.sprite;
        segundaImagen.sprite = temporal;

        // Actualiza el estado persistente si alguno de los espacios es un atajo.
        if (primerBoton is Atajo atajo1)
            ActualizarAtajo(atajo1);

        if (boton is Atajo atajo2)
            ActualizarAtajo(atajo2);

        // Guarda la nueva distribución del inventario.
        if (DesbloqueoElementos.Instance != null)
        {
            DesbloqueoElementos.Instance.ActualizarElementoInventario();
        }

        primerBoton = null;
    }

    private bool PuedeIntercambiar(
        IBotonInventario boton1,
        IBotonInventario boton2)
    {
        // Impide intercambiar directamente dos atajos.
        if (boton1 is Atajo && boton2 is Atajo)
            return false;

        return true;
    }

    private void ActualizarAtajo(Atajo atajo)
    {
        string nombreElemento = atajo.ObtenerNombreElemento();

        if (string.IsNullOrEmpty(nombreElemento))
            return;

        if (PoolElementos.Instance != null)
        {
            PoolElementos.Instance.ActivarElemento(nombreElemento);
        }
    }

    public void PanelAbierto(bool abierto)
    {
        cambioPermitido = abierto;

        // Evita conservar una selección al cerrar el panel.
        if (!abierto)
            primerBoton = null;
    }
}