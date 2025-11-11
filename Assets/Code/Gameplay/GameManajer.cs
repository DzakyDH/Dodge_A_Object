using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManajer : MonoBehaviour
{
    public static GameManajer Instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        if (SoundManajer.instance != null)
            SoundManajer.instance.PlayGameOverSound();
    }    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        ScoreManajer.Instance.ResetScore();

        // Hancurkan semua objek jatuh
        foreach (var obj in GameObject.FindGameObjectsWithTag("FallingObject"))
            Destroy(obj);

        // Reset posisi player
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(0, -3.5f, -1f);

        // Putar efek suara restart
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
            audio.Play();
        gameOverPanel.SetActive(false);
        if (SoundManajer.instance != null)
            SoundManajer.instance.PlayRestartSound();
    }
}
