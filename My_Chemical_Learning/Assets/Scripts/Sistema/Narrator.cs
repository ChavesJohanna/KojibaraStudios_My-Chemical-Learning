using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class Narrator : MonoBehaviour
{
    public static Narrator Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip[] clips;

    [Header("Auto Start Sequence")]
    [SerializeField] private int[] introSequence;
    [SerializeField] private float startDelay = 1f;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private float normalMusicVolume = -10f;
    [SerializeField] private float duckedMusicVolume = -20f;
    [SerializeField] private float fadeSpeed = 2f;

    private Queue<AudioClip> clipQueue = new Queue<AudioClip>();
    private bool isPlayingQueue = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(startDelay);

        // Si hay intro configurada, la encolamos
        if (introSequence != null && introSequence.Length > 0)
        {
            foreach (int index in introSequence)
            {
                QueueClip(index);
            }
        }
    }

    // -------------------------
    // PUBLIC API
    // -------------------------

    public void QueueClip(int index)
    {
        if (index < 0 || index >= clips.Length)
        {
            Debug.LogWarning("Índice de clip inválido.");
            return;
        }

        clipQueue.Enqueue(clips[index]);

        if (!isPlayingQueue)
        {
            StartCoroutine(PlayQueue());
        }
    }

    public void PlayNow(int index)
    {
        if (index < 0 || index >= clips.Length)
        {
            Debug.LogWarning("Índice de clip inválido.");
            return;
        }

        StopAllCoroutines();
        clipQueue.Clear();

        audioSource.Stop();
        audioSource.clip = clips[index];
        audioSource.Play();

        StartCoroutine(FadeMusic(normalMusicVolume));
        isPlayingQueue = false;
    }

    public bool IsSpeaking()
    {
        return audioSource.isPlaying || clipQueue.Count > 0;
    }

    public void StopNarration()
    {
        StopAllCoroutines();
        clipQueue.Clear();
        audioSource.Stop();

        StartCoroutine(FadeMusic(normalMusicVolume));
        isPlayingQueue = false;
    }

    // -------------------------
    // QUEUE SYSTEM
    // -------------------------

    private IEnumerator PlayQueue()
    {
        isPlayingQueue = true;

        yield return StartCoroutine(FadeMusic(duckedMusicVolume));

        while (clipQueue.Count > 0)
        {
            AudioClip clip = clipQueue.Dequeue();

            audioSource.clip = clip;
            audioSource.Play();

            yield return new WaitWhile(() => audioSource.isPlaying);
        }

        yield return StartCoroutine(FadeMusic(normalMusicVolume));

        isPlayingQueue = false;
    }

    // -------------------------
    // AUDIO DUCKING
    // -------------------------

    private IEnumerator FadeMusic(float targetVolume)
    {
        mixer.GetFloat("MusicVolume", out float currentVolume);

        while (Mathf.Abs(currentVolume - targetVolume) > 0.1f)
        {
            currentVolume = Mathf.Lerp(currentVolume, targetVolume, fadeSpeed * Time.deltaTime);
            mixer.SetFloat("MusicVolume", currentVolume);
            yield return null;
        }

        mixer.SetFloat("MusicVolume", targetVolume);
    }
}