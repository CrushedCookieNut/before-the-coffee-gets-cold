using UnityEngine;

public class MusicTrigger : MonoBehaviour {
    public int trackIndex;

    private void OnMouseDown() {
        if (AudioManager.instance != null) {
            AudioManager.instance.PlayMusic(trackIndex);
            AudioManager.instance.EnsureAudioPlaying();
        }
    }
}