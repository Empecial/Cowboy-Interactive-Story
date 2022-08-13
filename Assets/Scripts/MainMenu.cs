using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button QuitButton;

    public TextMeshProUGUI quitTxt;

    public GameObject VideoRenderTex;
    public VideoPlayer IntroVidPlayer;

    public AudioSource audiosrc;
    public AudioClip Startup;

    public RawImage ControlImage;

        

    public float timer;
    public bool VideoStart;

    private void Awake()
    {
        ControlImage.enabled = true;

        audiosrc.clip = Startup;

        VideoRenderTex.SetActive(false);
        IntroVidPlayer.Stop();
    }

    public void PlayGame()
    {
        audiosrc.volume = 0.10f;
        VideoStart = true;

        VideoRenderTex.SetActive(true);

        IntroVidPlayer.Play();
        
    }


    private void Update()
    {

        if (VideoStart)
        {
            timer -= Time.deltaTime;

            if( timer <= 0)
            {
                SceneManager.LoadScene(1);
            }

            if (Input.anyKeyDown)
            {
                //Destroy(VideoRenderTex);

                SceneManager.LoadScene(1);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ShowControls()
    {
        ControlImage.enabled=true;
        print("image enabled");
    }

    public void HideControls()
    {
        ControlImage.enabled = false;
    }

}
 