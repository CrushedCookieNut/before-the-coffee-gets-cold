using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public int trackIndex;  // The music track assigned to this object

    private void OnMouseDown()
    {
        // Ensure that AudioManager is available before trying to play music
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(trackIndex); // Play the music for this asset
            AudioManager.instance.EnsureAudioPlaying();  // Ensure music keeps playing across scenes
        }
    }
}