// System
using System;

// Unity
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
//using LitJson;
using System.Net;

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

    //[Header("Popups")]
    //public AlertPopup loginPopup = null;

    [Header("Settings")]
    public float fadeDuration = 1.0f;

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
        btn_signup_send.onClick.AddListener(OnLoginButtonClicked);
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
        SceneManager.LoadScene("Lobby");

        int accountType = 0;
        string id = input_id.text.Trim();
        string password = input_password.text.Trim();

        //if (id == string.Empty || password == string.Empty)
        //{
        //    loginPopup.ShowDialog("알림", "아이디 또는 비밀번호를 입력해주세요");
        //    return;
        //}

        #region WEBREQUESTOR
        LoginData loginData = new LoginData
        {
            accountType = accountType,
            id = id,
            password = password
        };

        //string json = JsonMapper.ToJson(loginData);
        //WebRequestor.Post("https://perdoco-lobby-prod.koreacentral.cloudapp.azure.com/api/Lobby/Login", json, (responseCode, result) =>
        //{
        //    if (responseCode == ResultCode.SUCCESS)
        //    {
        //        JsonData commonData = JsonMapper.ToObject(result);
        //        int resultCode = commonData[nameof(resultCode)].IntegerValue(200);
        //        string code = commonData[nameof(code)].StringValue();
        //        string description = commonData[nameof(description)].StringValue();
        //        string jwtToken = commonData[nameof(jwtToken)].StringValue();

        //        if (resultCode == 1 || resultCode == 2 || resultCode == 7)
        //        {
        //            loginPopup.ShowDialog("알림", $"아이디와 비밀번호를 확인해주세요.");
        //            return;
        //        }


        //        if (resultCode != 200)
        //        {
        //            loginPopup.ShowDialog("알림", $"서버와의 통신에 실패했습니다.");
        //            return;
        //        }


        //        JsonData studentData = commonData["student"];
        //        int studentNo = studentData[nameof(studentNo)].IntegerValue();
        //        string _class = studentData["class"].StringValue();
        //        string createDate = studentData[nameof(createDate)].StringValue();
        //        string grade = studentData[nameof(grade)].StringValue();
        //        string id = studentData[nameof(id)].StringValue();
        //        bool isFirstLogin = studentData[nameof(isFirstLogin)].BoolValue();
        //        string name = studentData[nameof(name)].StringValue();
        //        int number = studentData[nameof(number)].IntegerValue();
        //        string updateDate = studentData[nameof(updateDate)].StringValue();
        //        bool validity = studentData[nameof(validity)].BoolValue();
        //        int managerNo = studentData[nameof(managerNo)].IntegerValue();
        //        int schoolNo = studentData[nameof(schoolNo)].IntegerValue();
        //        bool passwordReset = studentData[nameof(passwordReset)].BoolValue();

        //        UserData.studentNo = studentNo;
        //        UserData._class = _class;
        //        UserData.createDate = createDate;
        //        UserData.grade = grade;
        //        UserData.id = id;
        //        UserData.password = password;
        //        UserData.isFirstLogin = isFirstLogin;
        //        UserData.name = name;
        //        UserData.number = number;
        //        UserData.updateDate = updateDate;
        //        UserData.validity = validity;
        //        UserData.managerNo = managerNo;
        //        UserData.schoolNo = schoolNo;
        //        UserData.passwordReset = passwordReset;
        //        UserData.jwtToken = jwtToken;

        //        if (toggle_remember_user_date.isOn)
        //        {
        //            PlayerPrefs.SetInt("toggle", 1);
        //            PlayerPrefs.SetString("id", id);
        //            PlayerPrefs.SetString("password", password);
        //        }
        //        else
        //        {
        //            PlayerPrefs.SetInt("toggle", 0);
        //            PlayerPrefs.SetString("id", string.Empty);
        //            PlayerPrefs.SetString("password", string.Empty);
        //        }

        //        ScreenHelper.FadeOut(fadeDuration, () =>
        //        {
        //            Debug.LogNetwork("Scene Load Start", "SceneName._01_Login -> SceneName._98_ServerConnection");
        //            SceneManager.LoadScene(SceneName._98_ServerConnection);
        //        });
        //    }
        //    else
        //    {
        //        loginPopup.ShowDialog("알림", $"서버와의 통신에 실패했습니다.\n인터넷 연결 상태를 확인해주세요"); // \n({responseCode})
        //    }
        //});
        #endregion
    }

    private void OnSignupSendButtonClicked()
    {
        //SceneManager.LoadScene("Lobby");
    }

    [Serializable]
    public class LoginData
    {
        public int accountType;
        public string id;
        public string password;
    }
}