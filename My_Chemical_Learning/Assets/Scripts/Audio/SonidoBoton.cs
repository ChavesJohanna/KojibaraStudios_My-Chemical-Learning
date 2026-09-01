using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SonidoBoton : MonoBehaviour
{

    //Singleton
    public static SonidoBoton Instancia { get; private set; }

    private void Awake() { 
        if (Instancia != null && Instancia != this) 
        {
            Destroy(gameObject); return; 
        } 
        Instancia = this; 
    }
    //Singleton


    private AudioSource sonido; //componente del gameobject
    private float volumen = 0.5f; //define el volumen por defecto

    private void Start()
    {
        sonido = GetComponent<AudioSource>(); //obtiene el componente

        sonido.volume = volumen; //le asiga el volumen por defecto al sonido



        sonido.playOnAwake = false; //evita ejecutar el sonido al iniciar la escena
        sonido.time = 00.06f; //determina el inico del clip de audio

    }

    public void ReproducirSonido()
    {
        sonido?.Play();
    }

    public void NuevoVolumen(float nuevo) //servira al momento de configurar los volumenes mas adelante
    {
        sonido.volume = nuevo;
    }
}
