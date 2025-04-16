using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioClip[] musicTracks;

    private AudioSource audioSource;
    private int currentTrackIndex = -1;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            if (audioSource == null) {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = 1f;

            SceneManager.sceneLoaded += OnSceneLoaded;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        EnsureAudioPlaying();
    }

    public void PlayMusic(int trackIndex) {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length) {
            if (currentTrackIndex != trackIndex) {
                currentTrackIndex = trackIndex;
                audioSource.clip = musicTracks[trackIndex];
                audioSource.Play();
            }
        }
    }

    public void EnsureAudioPlaying() {
        if (audioSource != null && !audioSource.isPlaying && currentTrackIndex >= 0 && musicTracks.Length > 0 && currentTrackIndex < musicTracks.Length) {
             audioSource.clip = musicTracks[currentTrackIndex];
             audioSource.Play();
        }
    }
}