using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Fuentes de audio")]
    [SerializeField] private AudioSource musicaSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Música")]
    [SerializeField] private AudioClip[] musicas;
    [SerializeField] private AudioClip musicaVictoria;
    [SerializeField] private AudioClip musicaDerrota;

    [Header("SFX de botones")]
    [SerializeField] private AudioClip sonidoBoton;
    [SerializeField] private AudioClip sonidoBotonPausa;

    [Header("SFX de disparos")]
    [SerializeField] private AudioClip[] sonidosDisparo;

    [Header("SFX de juego")]
    [SerializeField] private AudioClip sonidoMuerteEnemigo;
    [SerializeField] private AudioClip sonidoMesaTrabajo;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ReproducirMusicaDeEscena(
            SceneManager.GetActiveScene().name
        );
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AlCargarEscena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        ReproducirMusicaDeEscena(escena.name);
    }

    private void ReproducirMusicaDeEscena(string nombreEscena)
    {
        switch (nombreEscena)
        {
            case "MenuPrincipal":
                ReproducirMusica(0);
                break;

            case "Nivel1":
                ReproducirMusica(1);
                break;

            case "Nivel2":
                ReproducirMusica(2);
                break;

            case "MesaTrabajo":
                return;

            default:
                return;
        }
    }

    private void ReproducirMusica(int indice)
    {
        AudioClip nuevaMusica = musicas[indice];

        if (musicaSource.clip == nuevaMusica &&
            musicaSource.isPlaying)
        {
            return;
        }

        musicaSource.clip = nuevaMusica;
        musicaSource.loop = true;
        musicaSource.Play();
    }

    public void ReproducirVictoria()
    {
        musicaSource.clip = musicaVictoria;
        musicaSource.loop = true;
        musicaSource.Play();
    }

    public void ReproducirDerrota()
    {
        musicaSource.clip = musicaDerrota;
        musicaSource.loop = true;
        musicaSource.Play();
    }

    public void DetenerMusica()
    {
        musicaSource.Stop();
        musicaSource.clip = null;
    }

    public void CambiarVolumenMusica(float volumen)
    {
        Debug.Log(
            "ANTES Clip: " + musicaSource.clip +
            " Reproduciendo: " + musicaSource.isPlaying
        );

        musicaSource.volume = volumen;

        Debug.Log(
            "DESPUES Clip: " + musicaSource.clip +
            " Reproduciendo: " + musicaSource.isPlaying +
            " Volumen: " + musicaSource.volume
        );
    }

    public void CambiarVolumenSFX(float volumen)
    {
        sfxSource.volume = volumen;
    }

    public void ReproducirBoton()
    {
        sfxSource.PlayOneShot(sonidoBoton);
    }

    public void ReproducirBotonPausa()
    {
        sfxSource.PlayOneShot(sonidoBotonPausa);
    }

    public void ReproducirDisparo(int indice)
    {
        AudioClip sonido = sonidosDisparo[indice];

        sfxSource.PlayOneShot(sonido);
    }

    public void ReproducirMuerteEnemigo()
    {
        sfxSource.PlayOneShot(sonidoMuerteEnemigo);
    }

    public void ReproducirMesaTrabajo()
    {
        sfxSource.PlayOneShot(sonidoMesaTrabajo);
    }
    public void ProbarVolumen()
    {
        musicaSource.volume = 0f;
    }
}