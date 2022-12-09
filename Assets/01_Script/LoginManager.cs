// System
using System;
using System.Collections;

// Unity
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

using TMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class LoginManager : MonoBehaviour
{
    [Header("Title Screen")]
    public Button btn_sign_up = null;
    public Button btn_login_screen = null;

    [Header("Login Screen")]
    public GameObject go_pnl_login_screen = null;
    public Button btn_close_login_screen = null;
    public TMP_InputField input_id = null;
    public TMP_InputField input_password = null;
    public Button btn_login = null;

    [Header("SignUp Screen")]
    public GameObject go_pnl_signup_screen = null;
    public Button btn_close_signup_screen = null;
    public TMP_InputField input_name_S = null;
    public TMP_InputField input_school_S = null;
    public TMP_InputField input_stid_S = null;
    public TMP_InputField input_id_S = null;
    public TMP_InputField input_password_S = null;
    public Button btn_signup_send = null;

    [Header("Popups")]
    public GameObject alertPopup = null;
    public TextMeshProUGUI alertText = null;
    public Button buttonCloseAlert = null;

    [Header("Settings")]
    public float fadeDuration = 1.0f;

    [Header("UserData")]
    public UserData userData = null;

    string url = "http://3.38.107.143:8080/api/";

    private void Awake()
    {
        //Debug.LogNetwork("Scene Loaded", "SceneName._01_Login");
        AddListeners();
    }

    private void AddListeners()
    {
        btn_login_screen.onClick.AddListener(OnLoginScreenButtonClicked);
        btn_close_login_screen.onClick.AddListener(OnCloseLoginScreenButtonClicked);
        btn_sign_up.onClick.AddListener(OnSignupScreenButtonClicked);
        btn_close_signup_screen.onClick.AddListener(OnCloseSignupScreenButtonClicked);
        btn_login.onClick.AddListener(OnLoginButtonClicked);
        btn_signup_send.onClick.AddListener(OnSignupSendButtonClicked);
        buttonCloseAlert.onClick.AddListener(OnCloseAlertButtonClicked);
    }

    private void OnLoginScreenButtonClicked(){
        go_pnl_login_screen.SetActive(true);
    }

    private void OnCloseLoginScreenButtonClicked()
    {
        input_id.text = string.Empty;
        input_password.text = string.Empty;
        go_pnl_login_screen.SetActive(false);
    }

    private void OnSignupScreenButtonClicked()
    {
        go_pnl_signup_screen.SetActive(true);
    }

    private void OnCloseSignupScreenButtonClicked()
    {
        input_id_S.text = string.Empty;
        input_password_S.text = string.Empty;
        input_name_S.text = string.Empty;
        input_school_S.text = string.Empty;
        input_stid_S.text = string.Empty;
        go_pnl_signup_screen.SetActive(false);
    }

    private void OnLoginButtonClicked()
    {
        string id = input_id.text.Trim();
        string password = input_password.text.Trim();

        JObject loginObject = new JObject
        {
            { "email", id },
            { "password", password }
        };

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
        {
            AlertPopup("아이디 또는 비밀번호를 입력해주세요");
            return;
        }

        StartCoroutine(LogIn(JsonConvert.SerializeObject(loginObject)));
    }

    private void OnSignupSendButtonClicked()
    {
        string name = input_name_S.text.Trim();
        string school = input_school_S.text.Trim();
        string stid = input_stid_S.text.Trim();
        string id = input_id_S.text.Trim();
        string password = input_password_S.text.Trim();

        JObject signupObject = new()
        {
            { "email", id },
            { "name", name },
            { "password", password },
            { "school", school },
            { "studentNumber", stid }
        };

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(school) || string.IsNullOrEmpty(stid)
            || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
        {
            AlertPopup("회원가입에 필요한 정보를 입력해주세요");
            return;
        }

        StartCoroutine(SignUp(JsonConvert.SerializeObject(signupObject)));
    }

    private void OnCloseAlertButtonClicked()
    {
        alertPopup.SetActive(false);
    }

    private void AlertPopup(string text)
    {
        alertPopup.SetActive(true);
        alertText.text = text;
    }

    private IEnumerator LogIn(string json)
    {
        using UnityWebRequest www = UnityWebRequest.Post(url + "auth/signin", json);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("accept", "*/*");
        //www.SetRequestHeader("Authorization", token);

        yield return www.SendWebRequest();

        if (www.responseCode == 200)
        {
            SceneManager.LoadScene("Lobby");
            JObject responseBody = JObject.Parse(www.downloadHandler.text);
            string token = responseBody["result"]["token"].ToString();
            userData.SetToken(url, token);
        }
        else
        {
            AlertPopup("연결에 실패하였습니다.");
        }
    }

    private IEnumerator SignUp(string json)
    {
        using UnityWebRequest www = UnityWebRequest.Post(url + "auth/signup", json);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("accept", "*/*");

        yield return www.SendWebRequest();

        if (www.responseCode == 200)
        {
            AlertPopup("회원가입에 성공했습니다.");
        }
        else if (www.responseCode == 409)
        {
            AlertPopup("이미 가입된 아이디입니다.");
        }
        else
        {
            AlertPopup("회원가입에 실패했습니다.");
        }
    }
}