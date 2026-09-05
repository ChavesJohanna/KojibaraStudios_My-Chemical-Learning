using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //permite cargar escenas
using System.Collections; //permite utilizar Coroutine

public class BotonJugar : MonoBehaviour
{
    private Button boton; //componente del gameobject
    private string nombreNivel; //nombre de la escena

    private float delay = 0.3f; //delay que permitira que suene el boton antes de cargar el nivel

    private void Start()
    {
        boton = GetComponent<Button>(); //obtiene el componente (de no colocarlo este tirara error)
        nombreNivel = "Nivel1";

        boton.onClick.AddListener(Jugar); //ejecuta el metodo colocado entre parentesis al clikear el boton
    }

    private void Jugar()
    {
        GuardarPartida.ResetearDatos(); //reinicia los datos 

        boton.interactable = false; //desactiva la interacción del botón
        StartCoroutine(CargarNivel()); //inicia la espera
    } 

    private IEnumerator CargarNivel() 
    { 
        SonidoBoton.Instancia.ReproducirSonido(); //hace sonar el boton

        yield return new WaitForSeconds(delay); //espera el tiempo indicado

        SceneManager.LoadScene(nombreNivel); //carga la escena
    }
}
