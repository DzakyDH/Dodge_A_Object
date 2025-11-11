using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class RestartController : MonoBehaviour
{
    public GameObject restartPanel;       // Panel atau video canvas
    public VideoPlayer videoPlayer;       // (Opsional) jika pakai video
    public float restartDelay = 2f;       // Tunggu berapa detik sebelum restart

    public void OnRestartButtonPressed()
    {
        // Aktifkan panel animasi
        restartPanel.SetActive(true);

        // Jika pakai video
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            StartCoroutine(RestartAfterVideo());
        }
        else
        {
            StartCoroutine(RestartAfterDelay());
        }
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        RestartGame();
    }

    private IEnumerator RestartAfterVideo()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        RestartGame();
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
