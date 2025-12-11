using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndHandler : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd; // Event called when the video finishes
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("_Menu");
    }
}
