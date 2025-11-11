using UnityEngine;

public class SoundManajer : MonoBehaviour
{
    public static SoundManajer instance;

    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioClip restartSound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayScoreSound()
    {
        if (scoreSound != null)
            audioSource.PlayOneShot(scoreSound);
    }
    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
            audioSource.PlayOneShot(gameOverSound);
    }
    public void PlayRestartSound()
    {
        if (gameOverSound != null)
            audioSource.PlayOneShot(restartSound);
    }
}