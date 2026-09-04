using UnityEngine;

public class ControladorAtajos : MonoBehaviour
{
    private Atajo atajoActivo;

    public void Seleccionar(Atajo atajo)
    {
        if (atajo == null) 
            return;
            

        if (atajoActivo != null) //desactiva el atajo anterior
            atajoActivo.Desactivar(); 

        atajoActivo = atajo; //reasigna el nuevo atajo
        atajo.Activar(); //activa la imagen "Activado" que tiene el nuevo atajo selecionado


        string nombreElemento = atajo.ObtenerNombreElemento(); //obtiene el nombre de el elemeto selecionado

        if (nombreElemento == null) 
            return;

        PoolElementos.Instance.ActivarElemento(nombreElemento); //se lo envia al pool para q el jugador lo dispare
    }
}
