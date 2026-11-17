
using System.Collections;
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
    [SerializeField] private AudioClip musicaCreditos;

    [Header("SFX de botones")]
    [SerializeField] private AudioClip sonidoBoton;
    [SerializeField] private AudioClip sonidoBotonPausa;

    [Header("SFX de disparos")]
    [SerializeField] private AudioClip[] sonidosDisparo;

    [Header("SFX de juego")]
    [SerializeField] private AudioClip sonidoMuerteEnemigo;
    [SerializeField] private AudioClip sonidoMesaTrabajo;
    [SerializeField] private AudioClip sonidoContactoZapper;

    [Header("SFX de diálogos")]
    [SerializeField] private AudioClip[] sonidosDialogos;

    [Header("Volumen durante diálogos")]
    [SerializeField, Range(0f, 1f)] private float multiplicadorVolumenDuranteDialogo = 0.25f;
    [SerializeField] private float velocidadTransicionMusica = 2f;

    [Header("Volumen de diálogos")]
    [SerializeField, Range(0f, 2f)] private float volumenDialogos = 1.5f;

    private float volumenMusicaConfigurado;
    private float factorVolumenMusica = 1f;

    private float finDialogo;
    private Coroutine corrutinaDuckMusica;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Guarda el volumen configurado inicialmente.
        volumenMusicaConfigurado = musicaSource.volume;

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

        if (escena.name == "MesaTrabajo")
        {
            ReproducirMesaTrabajo();
        }
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

            case "Creditos":
                ReproducirMusicaCreditos();
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
        AplicarVolumenMusica();
        musicaSource.Play();
    }

    private void ReproducirMusicaCreditos()
    {
        if (musicaCreditos == null)
            return;

        // Evita reiniciar la música si ya está reproduciéndose.
        if (musicaSource.clip == musicaCreditos &&
            musicaSource.isPlaying)
        {
            return;
        }

        musicaSource.Stop();
        musicaSource.clip = musicaCreditos;

        // La música de créditos se reproduce una sola vez.
        musicaSource.loop = false;

        AplicarVolumenMusica();
        musicaSource.Play();
    }

    public void ReproducirVictoria()
    {
        musicaSource.clip = musicaVictoria;
        musicaSource.loop = true;
        AplicarVolumenMusica();
        musicaSource.Play();
    }

    public void ReproducirDerrota()
    {
        musicaSource.clip = musicaDerrota;
        musicaSource.loop = true;
        AplicarVolumenMusica();
        musicaSource.Play();
    }

    public void DetenerMusica()
    {
        musicaSource.Stop();
        musicaSource.clip = null;
    }

    public void CambiarVolumenMusica(float volumen)
    {
        // Guarda el volumen elegido por el usuario.
        volumenMusicaConfigurado = Mathf.Clamp01(volumen);

        AplicarVolumenMusica();
    }

    private void AplicarVolumenMusica()
    {
        musicaSource.volume =
            volumenMusicaConfigurado * factorVolumenMusica;
    }

    public void CambiarVolumenSFX(float volumen)
    {
        sfxSource.volume = volumen;
    }

    public float ObtenerVolumenMusica()
    {
        return volumenMusicaConfigurado;
    }

    public float ObtenerVolumenSFX()
    {
        return sfxSource.volume;
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

    public void ReproducirContactoZapper()
    {
        sfxSource.PlayOneShot(sonidoContactoZapper);
    }

    public void ReproducirDialogo(AudioClip sonido)
    {
        if (sonido == null)
            return;

        // Reproduce la voz con volumen independiente.
        sfxSource.PlayOneShot(sonido, volumenDialogos);

        // Actualiza el momento de finalización del último diálogo.
        finDialogo = Mathf.Max(
            finDialogo,
            Time.unscaledTime + sonido.length
        );

        // Inicia el control del volumen si todavía no está activo.
        if (corrutinaDuckMusica == null)
        {
            corrutinaDuckMusica = StartCoroutine(
                ControlarVolumenMusica()
            );
        }
    }

    private IEnumerator ControlarVolumenMusica()
    {
        while (true)
        {
            // Reduce gradualmente el volumen mientras haya diálogos.
            while (Time.unscaledTime < finDialogo)
            {
                factorVolumenMusica = Mathf.MoveTowards(
                    factorVolumenMusica,
                    multiplicadorVolumenDuranteDialogo,
                    velocidadTransicionMusica * Time.unscaledDeltaTime
                );

                AplicarVolumenMusica();

                yield return null;
            }

            // Recupera gradualmente el volumen original.
            while (factorVolumenMusica < 1f)
            {
                factorVolumenMusica = Mathf.MoveTowards(
                    factorVolumenMusica,
                    1f,
                    velocidadTransicionMusica * Time.unscaledDeltaTime
                );

                AplicarVolumenMusica();

                // Si comienza otro diálogo, interrumpe la recuperación.
                if (Time.unscaledTime < finDialogo)
                    break;

                yield return null;
            }

            // Finaliza cuando la música recuperó su volumen.
            if (Time.unscaledTime >= finDialogo &&
                factorVolumenMusica >= 1f)
            {
                corrutinaDuckMusica = null;
                yield break;
            }
        }
    }
}
