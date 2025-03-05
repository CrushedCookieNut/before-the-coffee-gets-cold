using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance
    public AudioClip[] musicTracks;      // Array of music tracks

    private AudioSource audioSource;      // AudioSource for playing music
    private int currentTrackIndex = -1;  // Track index to keep track of current playing track

    private void Awake()
    {
        // Check if an instance of AudioManager already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes

            // Create AudioSource if it doesn't exist
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Ensure the AudioSource settings are correct
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = 1f;

            // Subscribe to scene load event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Destroy this new instance if one already exists
            return; // Don't execute further code for this object
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from scene load event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure audio is still playing and settings are correct after scene load
        EnsureAudioPlaying();
    }

    // This method will play a selected track
    public void PlayMusic(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            if (currentTrackIndex != trackIndex) // Don't restart the same track
            {
                currentTrackIndex = trackIndex;
                audioSource.clip = musicTracks[trackIndex];
                audioSource.Play(); // Start playing the selected track
            }
        }
    }

    // Method to ensure the audio continues playing across scenes
    public void EnsureAudioPlaying()
    {
        if (audioSource != null && !audioSource.isPlaying && currentTrackIndex >= 0 && musicTracks.Length > 0 && currentTrackIndex < musicTracks.Length)
        {
             audioSource.clip = musicTracks[currentTrackIndex];
             audioSource.Play(); // Start playing the current track if not already playing
        }
    }
}