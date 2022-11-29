using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource[] audioSources;

    public Slider soundBar;
    [SerializeField] private GameObject g_soundBar;

    public Text volumText;

    public GameObject[] onoff_Img;

    //bool isShowSoundBar = false;
    int audioLegnth;

    private bool isMute = false;
    private float curVolume = 0;
    private bool isShowSoundBar = false;

    private bool isTouchSoundBar = false;

    public AudioSource[] noAutioAudio;

    // Start is called before the first frame update
    void Start()
    {
        //audioSources = GameObject.FindObjectOfType(typeof(AudioSource)) as AudioSource;
        AudioSource_Init();
    }

    void AudioSource_Init()
    {

        audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        //audioSources = Transform.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        //audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        audioLegnth = audioSources.Length;
        Debug.Log("audioSources : " + audioSources.Length);
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(2))
        //{
        //    isShowSoundBar = !isShowSoundBar;
        //    soundBar.gameObject.SetActive(isShowSoundBar);
        //}
        if (true)//isShowSoundBar)
        {
            //Vector2 wheelInput2 = Input.mouseScrollDelta;
            //if (wheelInput2.y > 0)
            //{
            //   // Debug.Log("Wheel UP");
            //    soundBar.value += 1f;
            //}
            //else if (wheelInput2.y < 0)
            //{
            //   // Debug.Log("Wheel Down");
            //    soundBar.value -= 1f;
            //}
            if (soundBar.value > 0)
            {
                onoff_Img[0].SetActive(false);
                onoff_Img[1].SetActive(true);
                if (isMute)
                {
                    for (int i = 0; i < audioLegnth; i++)
                    {
                        audioSources[i].mute = false;
                    }
                    for (int i = 0; i < noAutioAudio.Length; i++)
                    {
                        noAutioAudio[i].mute = false;
                    }
                    isMute = false;
                }
            }
            else
            {
                onoff_Img[0].SetActive(true);
                onoff_Img[1].SetActive(false);
            }
        }


    }

    public void B_OpenSoundQuickMenu()
    {
        if (isShowSoundBar)
        {
        }
        else
        {
            g_soundBar.SetActive(true);
            Invoke("SetBoolSoundBar", 0.2f);
        }
    }

    private void SetBoolSoundBar()
    {
        if (!isShowSoundBar) isShowSoundBar = true;
    }

    public void ResetBoolSoundBar()
    {
        isShowSoundBar = false;
    }

    public void HideSoundBar()
    {
        isShowSoundBar = false;
        g_soundBar.SetActive(false);
    }

    public bool isSoundBar()
    {
        return g_soundBar.activeSelf;
    }

    public bool isTouchingSoundBar()
    {
        return isTouchSoundBar;
    }

    public void SetIsTouchSoundBar()
    {
        if (isTouchSoundBar == false)
        {
            isTouchSoundBar = true;
        }
    }

    public void ResetIsTouchSoundBar()
    {
        isTouchSoundBar = false;
    }

    public void Chage_Volum()
    {
        for (int i = 0; i < audioLegnth; i++)
        {
            audioSources[i].volume = soundBar.value / 100;
            // Debug.Log(audioSources[i].volume);
        }

        for (int i = 0; i < noAutioAudio.Length; i++)
        {
            noAutioAudio[i].volume = soundBar.value / 100;
            // Debug.Log(audioSources[i].volume);
        }


        volumText.text = soundBar.value.ToString("0");
    }


    public void MuteSound()
    {
        if (isShowSoundBar)
        {
            if (isMute)
            {
                isMute = false;
                for (int i = 0; i < audioLegnth; i++)
                {
                    audioSources[i].mute = false;
                }
                for (int i = 0; i < noAutioAudio.Length; i++)
                {
                    noAutioAudio[i].mute = false;
                }

                soundBar.value = curVolume;

            }
            else
            {
                isMute = true;
                curVolume = soundBar.value;
                for (int i = 0; i < audioLegnth; i++)
                {
                    audioSources[i].mute = true;
                }
                for (int i = 0; i < noAutioAudio.Length; i++)
                {
                    noAutioAudio[i].mute = true;
                }

                //curVolume = soundBar.value/100;
                soundBar.value = 0;
            }
        }
    }


    private static SoundManager instance;
    public static SoundManager inst
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType(typeof(SoundManager)) as SoundManager;
            return instance;
        }
    }
}
