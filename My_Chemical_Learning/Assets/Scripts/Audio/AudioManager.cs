
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
    [SerializeField] private AudioClip musicaJefe;

    [Header("Transiciones de música")]
    [SerializeField] private float duracionFade = 2f;

    [Header("SFX de botones")]
    [SerializeField] private AudioClip sonidoBoton;
    [SerializeField] private AudioClip sonidoBotonPausa;

    [Header("SFX de disparos")]
    [SerializeField] private AudioClip[] sonidosDisparo;

    [Header("SFX de juego")]
    [SerializeField] private AudioClip sonidoMuerteEnemigo;
    [SerializeField] private AudioClip sonidoMesaTrabajo;
    [SerializeField] private AudioClip sonidoContactoZapper;

    [Header("SFX del jefe")]
    [SerializeField] private AudioClip[] sonidosMovimientoBrazos;
    [SerializeField] private AudioClip[] sonidosDanioJefe;
    [SerializeField] private AudioClip sonidoGolpeJugadorJefe;

    [Header("SFX de diálogos")]
    [SerializeField] private AudioClip[] sonidosDialogos;

    [Header("Balance general de audio")]
    [SerializeField, Range(0f, 1f)]
    private float multiplicadorMusica = 0.6f;

    [SerializeField, Range(0f, 1f)]
    private float multiplicadorDisparos = 0.6f;

    [Header("Volumen durante diálogos")]
    [SerializeField, Range(0f, 1f)]
    private float multiplicadorVolumenDuranteDialogo = 0.25f;

    [SerializeField] private float velocidadTransicionMusica = 2f;

    [Header("Volumen de diálogos")]
    [SerializeField, Range(0f, 2f)]
    private float volumenDialogos = 1.5f;

    private float volumenMusicaConfigurado;
    private float volumenSFXConfigurado;

    private float factorVolumenMusica = 1f;

    // Controla el volumen de los fades de cambio de música.
    private float factorTransicionMusica = 1f;

    private float finDialogo;

    private bool bloquearSFX = false;

    private Coroutine corrutinaDuckMusica;
    private Coroutine corrutinaTransicionMusica;

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
        volumenSFXConfigurado = sfxSource.volume;

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
        // Detiene los sonidos que pertenecían a la escena anterior.
        sfxSource.Stop();

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

            case "Boss":
                ReproducirMusica(3);
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
        if (indice < 0 || indice >= musicas.Length ||
            musicas[indice] == null)
            return;

        // Permite reproducir SFX nuevamente.
        bloquearSFX = false;

        CancelarTransicionMusica();

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

        // Permite reproducir SFX nuevamente.
        bloquearSFX = false;

        CancelarTransicionMusica();

        if (musicaSource.clip == musicaCreditos &&
            musicaSource.isPlaying)
        {
            return;
        }

        musicaSource.Stop();
        musicaSource.clip = musicaCreditos;
        musicaSource.loop = false;

        AplicarVolumenMusica();
        musicaSource.Play();
    }

    public void ReproducirVictoria()
    {
        // Bloquea los SFX, excepto los de botones.
        bloquearSFX = true;

        sfxSource.Stop();

        CancelarTransicionMusica();

        musicaSource.clip = musicaVictoria;
        musicaSource.loop = true;

        AplicarVolumenMusica();
        musicaSource.Play();
    }

    public void ReproducirDerrota()
    {
        // Bloquea los SFX, excepto los de botones.
        bloquearSFX = true;

        sfxSource.Stop();

        CancelarTransicionMusica();

        musicaSource.clip = musicaDerrota;
        musicaSource.loop = true;

        AplicarVolumenMusica();
        musicaSource.Play();
    }

    public void DetenerMusica()
    {
        CancelarTransicionMusica();

        musicaSource.Stop();
        musicaSource.clip = null;
    }

    // Inicia la música del jefe mediante una transición.
    public void IniciarMusicaJefe()
    {
        if (musicaJefe == null)
            return;

        // Permite reproducir SFX durante la música del jefe.
        bloquearSFX = false;

        CambiarMusicaConFade(musicaJefe);
    }

    // Recupera la música del nivel 3 mediante una transición.
    public void RestaurarMusicaNivel3()
    {
        if (musicas.Length <= 3 || musicas[3] == null)
            return;

        // Permite reproducir SFX nuevamente.
        bloquearSFX = false;

        CambiarMusicaConFade(musicas[3]);
    }

    // Gestiona el cambio entre dos pistas musicales.
    private void CambiarMusicaConFade(AudioClip nuevaMusica)
    {
        if (nuevaMusica == null)
            return;

        // Evita ejecutar varias transiciones simultáneamente.
        CancelarTransicionMusica();

        corrutinaTransicionMusica = StartCoroutine(
            TransicionarMusica(nuevaMusica)
        );
    }

    private IEnumerator TransicionarMusica(AudioClip nuevaMusica)
    {
        float duracion = Mathf.Max(0.01f, duracionFade);

        // FADE OUT: reduce el volumen de la música actual.
        while (factorTransicionMusica > 0f)
        {
            factorTransicionMusica = Mathf.MoveTowards(
                factorTransicionMusica,
                0f,
                Time.unscaledDeltaTime / duracion
            );

            AplicarVolumenMusica();

            yield return null;
        }

        // Cambia la pista cuando la anterior ya no se escucha.
        musicaSource.Stop();
        musicaSource.clip = nuevaMusica;
        musicaSource.loop = true;

        musicaSource.Play();

        // FADE IN: aumenta progresivamente el volumen.
        while (factorTransicionMusica < 1f)
        {
            factorTransicionMusica = Mathf.MoveTowards(
                factorTransicionMusica,
                1f,
                Time.unscaledDeltaTime / duracion
            );

            AplicarVolumenMusica();

            yield return null;
        }

        factorTransicionMusica = 1f;
        AplicarVolumenMusica();

        corrutinaTransicionMusica = null;
    }

    private void CancelarTransicionMusica()
    {
        if (corrutinaTransicionMusica != null)
        {
            StopCoroutine(corrutinaTransicionMusica);
            corrutinaTransicionMusica = null;
        }

        factorTransicionMusica = 1f;
        AplicarVolumenMusica();
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
            volumenMusicaConfigurado *
            multiplicadorMusica *
            factorVolumenMusica *
            factorTransicionMusica;
    }

    public void CambiarVolumenSFX(float volumen)
    {
        volumenSFXConfigurado = Mathf.Clamp01(volumen);
        AplicarVolumenSFX();
    }

    private void AplicarVolumenSFX()
    {
        sfxSource.volume = volumenSFXConfigurado;
    }

    public float ObtenerVolumenMusica()
    {
        return volumenMusicaConfigurado;
    }

    public float ObtenerVolumenSFX()
    {
        return volumenSFXConfigurado;
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
        if (bloquearSFX) return;

        if (indice < 0 || indice >= sonidosDisparo.Length)
            return;

        AudioClip sonido = sonidosDisparo[indice];

        if (sonido != null)
            sfxSource.PlayOneShot(sonido, multiplicadorDisparos);
    }

    public void ReproducirMuerteEnemigo()
    {
        if (bloquearSFX) return;

        sfxSource.PlayOneShot(sonidoMuerteEnemigo);
    }

    public void ReproducirMesaTrabajo()
    {
        if (bloquearSFX) return;

        sfxSource.PlayOneShot(sonidoMesaTrabajo);
    }

    public void ReproducirContactoZapper()
    {
        if (bloquearSFX) return;

        sfxSource.PlayOneShot(sonidoContactoZapper);
    }

    // Reproduce aleatoriamente uno de los sonidos de movimiento de brazos.
    public void ReproducirMovimientoBrazos()
    {
        if (bloquearSFX ||
            sonidosMovimientoBrazos == null ||
            sonidosMovimientoBrazos.Length == 0)
            return;

        AudioClip sonido = sonidosMovimientoBrazos[
            Random.Range(0, sonidosMovimientoBrazos.Length)
        ];

        if (sonido != null)
            sfxSource.PlayOneShot(sonido);
    }

    // Reproduce aleatoriamente uno de los sonidos de daño del jefe.
    public void ReproducirDanioJefe()
    {
        if (bloquearSFX ||
            sonidosDanioJefe == null ||
            sonidosDanioJefe.Length == 0)
            return;

        AudioClip sonido = sonidosDanioJefe[
            Random.Range(0, sonidosDanioJefe.Length)
        ];

        if (sonido != null)
            sfxSource.PlayOneShot(sonido);
    }

    // Reproduce el sonido cuando el jefe golpea al jugador.
    public void ReproducirGolpeJugadorJefe()
    {
        if (bloquearSFX || sonidoGolpeJugadorJefe == null)
            return;

        sfxSource.PlayOneShot(sonidoGolpeJugadorJefe);
    }

    public void ReproducirDialogo(AudioClip sonido)
    {
        if (bloquearSFX || sonido == null)
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

    ///////// j estuvo aqui
    public string ObtenerPorcentajeMusica()
    {
        return Mathf.RoundToInt(volumenMusicaConfigurado * 100) + "%";
    }

    public string ObtenerPorcentajeEfectos()
    {
        return Mathf.RoundToInt(volumenSFXConfigurado * 100) + "%";
    }


}
