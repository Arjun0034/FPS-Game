using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource backgroundMusic;

    void Start()
    {
        // Assuming the AudioSource is attached to the same GameObject as this script
        backgroundMusic = GetComponent<AudioSource>();

        // Play the background music
        backgroundMusic.Play();
    }
}
