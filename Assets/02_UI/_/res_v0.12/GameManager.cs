using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance;
    public GameObject MenuObject;
    public GameObject PlayQuickMenu;
    public GameObject SoundBar;

    public GameObject fullScreenBtn, shrinkScreenBtn; // 전체화면 축소화면 버튼
    public GameObject MenuParentObj;
    public GameObject[] ScreenGuideImg;

    public GameObject fullImg;
    public GameObject shrinkImg;

    private bool isPlaying = true;

    public GameObject Cube;

    public GameObject image;
    public Transform player;
    Vector3 vector;

    public Animator MenuAnim;

    public GameObject Canvas_Defualt;
    public GameObject Canvas_Full;

    public GameObject volumController;
    public GameObject volumBarController;

    public GameObject MenuOnIcon;
    public GameObject MenuOffIcon;

    public Text Texts;


    public bool IsOpendVolumController { get
        {
            if (volumController)
            {
                return volumController.activeSelf;
            }
            else
            {
                return false;
            }
        }
    }

    public bool IsMenuObject
    {
        get
        {
            if (MenuObject)
            {
                return MenuObject.activeSelf;
            }
            else
            {
                return false;
            }
        }
    }

    private void Awake()
    {
        GMInstance = this;
        CloseMenu();

    }

    private void Start() {
        Invoke("ExitAnim", 3f);
        if(Screen.fullScreen)
        {
            Screen.fullScreen = true;
            fullImg.SetActive(false);
            shrinkImg.SetActive(true);
            //Canvas_Full.SetActive(false);
            //fullScreenBtn.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, 10, 0);
            //MenuParentObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(48, -35, 0);
        }
        else
        {
            Screen.fullScreen = false;
            fullImg.SetActive(true);
            shrinkImg.SetActive(false);
            //Canvas_Full.SetActive(true);
            //fullScreenBtn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40f, -98f, 0);
           // MenuParentObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }

        StartCoroutine(CheckFullScreen());
    }
    IEnumerator CheckFullScreen()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            if(Screen.fullScreen)
            {
                Screen.fullScreen = true;
                fullImg.SetActive(false);
                shrinkImg.SetActive(true);
                //Canvas_Defualt.SetActive(false);
                //Canvas_Full.SetActive(false);
                //fullScreenBtn.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, 10, 0);
                //MenuParentObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(48, -35, 0);
            }
            else
            {
                Screen.fullScreen = false;
                fullImg.SetActive(true);
                shrinkImg.SetActive(false);
                //Canvas_Defualt.SetActive(true);
                //Canvas_Full.SetActive(true);
                //fullScreenBtn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40f, -98f, 0);
                //MenuParentObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            }
        }
    }
    private void ExitAnim()
    {
        //NarrAnim.enabled = false;
    }


    public void RotationInit()
    {
        //WebGL_Common.WebGL_CameraController1.Instance
        //WebGL_Common.WebGL_CameraController.Instance.
    }

    private void Update()
    {
        vector.z = -player.eulerAngles.y;
        image.transform.localEulerAngles = vector;

        /*if (Input.GetMouseButtonDown(0)  && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Debug.Log("None UI Clicked");

            if (MenuObject.activeSelf)
            {
                if (SoundBar.activeSelf)
                {
                    SoundBar.SetActive(false);
                }
                else
                {
                    MenuAnim.SetTrigger("CloseMenu");
                    Invoke("CloseMenu", 0.5f);
                    MenuOffIcon.SetActive(true);
                    MenuOnIcon.SetActive(false);
                }
            }

        }*/

    }

    public void B_FullScreen()
    {
        if(Screen.fullScreen)
        {
            //Screen.orientation = ScreenOrientation.AutoRotation;
            Screen.fullScreen = false;
            fullImg.SetActive(true);
            shrinkImg.SetActive(false);
            //Canvas_Defualt.SetActive(true);
            //Canvas_Full.SetActive(true);
            //fullScreenBtn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40f, -98f, 0);
            //MenuParentObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else
        {
            Screen.fullScreen = true;
            //Screen.autorotateToLandscapeLeft = true;
            fullImg.SetActive(false);
            shrinkImg.SetActive(true);
            //Canvas_Defualt.SetActive(false);
            //Canvas_Full.SetActive(false);
            //fullScreenBtn.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, 10, 0);
            //MenuParentObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(48, -35, 0);
        }
    }
    public void B_OpenMenu()
    {
        if (MenuObject.activeSelf)
        {
            MenuAnim.SetTrigger("CloseMenu");
            Invoke("CloseMenu", 0.5f);
            Invoke("MenuIconOff", 0.5f);

            if (volumController)
            {
                volumController.SetActive(false);
            }
            if (volumBarController)
            {
                volumBarController.SetActive(false);
            }
        }
        else
        {
            MenuObject.SetActive(true);
            MenuAnim.SetTrigger("OpenMenu");
            Invoke("MenuIconOn", 0.5f);

            if (volumController)
            {
                volumController.SetActive(false);
            }
            if (volumBarController)
            {
                volumBarController.SetActive(false);
            }
        }
    }

    private void CloseMenu()
    {
        MenuObject.SetActive(false);
    }

    private void MenuIconOff()
    {
        MenuOffIcon.SetActive(true);
        MenuOnIcon.SetActive(false);
    }

    private void MenuIconOn()
    {
        MenuOffIcon.SetActive(false);
        MenuOnIcon.SetActive(true);
    }

    public void B_OpenQuickMenu(GameObject g)
    {
        if (g.activeSelf)
        {
            g.SetActive(false);
        }
        else
        {
            g.SetActive(true);
        }
    }

    public void B_OpenSoundQuickMenu(GameObject g)
    {
        if (g.activeSelf)
        {
        }
        else
        {
            g.SetActive(true);
        }
    }

    public void Q_FullScreenBtn()
    {
        if(Screen.fullScreen)
        {
            Screen.fullScreen = false;
            fullImg.SetActive(true);
            shrinkImg.SetActive(false);
        }
        else
        {
            Screen.fullScreen = true;
            fullImg.SetActive(false);
            shrinkImg.SetActive(true);
        }
    }

    public void xBtn(GameObject g)
    {
        if (isPlaying)
        {
            g.SetActive(false);
        }
        // else
        // {
        //     MainQuickMenu.SetActive(false);
        // }
    }

    public void GotoIntro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void B_ScreenGuide(GameObject g)
    {
        for(int i = 0; i < ScreenGuideImg.Length; i++)
        {
            ScreenGuideImg[i].SetActive(false);
        }
        g.SetActive(true);
    }
    public void QuitAndClose()
    {
        //Application.Quit();
        try
        {
             closeWindow();
        }
        catch(NullReferenceException e)
        {
            Debug.Log(e);
        }
       
    }

    public GameObject ExitMenu;
    public void ExitMenuOn()
    {
        ExitMenu.SetActive(true);
    }

    public GameObject HomeMenu;

    public void HomeMenuOn()
    {
        HomeMenu.SetActive(true);
    }

    public void Clickon()
    {
        Debug.Log("click");
    }

    [DllImport("__Internal")]
     private static extern void closeWindow();
}