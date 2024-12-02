using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string videoFileName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayVideo();
    }

    // Update is called once per frame
    

    public void PlayVideo()
    {
        VideoPlayer videoplayer = GetComponent<VideoPlayer>();
        if(videoplayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoplayer.url = videoPath;
            videoplayer.Play();
        }
    }
}
