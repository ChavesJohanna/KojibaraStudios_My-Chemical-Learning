using UnityEngine;
using UnityEngine.UI;
using System.Collections; //permite utilizar Coroutine

public class BotonSalir : MonoBehaviour
{
    private Button boton; //componente del gameobject
    private float delay = 0.3f; //delay que permitira que suene el boton antes de salir

    private void Start()
    {
        boton = GetComponent<Button>(); //obtiene el componente (de no colocarlo este tirara error)

        boton.onClick.AddListener(Salir); //ejecuta el metodo colocado entre parentesis al clikear el boton
    }

    private void Salir()
    {
        boton.interactable = false; //desactiva la interacción del botón
        StartCoroutine(CerrarJuego()); //inicia la espera    
    }

    private IEnumerator CerrarJuego()
    {
        SonidoBoton.Instancia.ReproducirSonido(); //hace sonar el boton

        yield return new WaitForSeconds(delay); //espera el tiempo indicado

        Application.Quit(); //cierra el ejecutable del juego

        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false; //desactiva el modo play del editor
        #endif

    }
}
