using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    private AudioSource musica; //componente del gameobject
    private float volumen = 0.5f; //define el volumen por defecto

    private void Start()
    {
        musica = GetComponent<AudioSource>();

        ReproducirMusica();
    }

    private void ReproducirMusica()
    {        
        musica.volume = volumen; //le asiga el volumen por defecto al sonido

        musica.playOnAwake = true; //evita ejecutar el sonido al iniciar la escena

        musica.loop = true; //se reproduce la musica en loop

        musica?.Play();
    }

    public void NuevoVolumen(float nuevo) //servira al momento de configurar los volumenes mas adelante
    {
        musica.volume = nuevo;
    }
}
