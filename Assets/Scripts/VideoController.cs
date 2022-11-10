using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject uiMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uiMenu.activeSelf == false && videoPlayer.isPlaying)
        {
            uiMenu.SetActive(true);
        }

        if (this.gameObject.activeSelf == false)
        {
            uiMenu.SetActive(true);
        }
    }
}
