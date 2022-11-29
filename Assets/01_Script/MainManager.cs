using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Camera mainCamera;

    public Button LeftButton;
    public Button RightButton;
    public Button UpButton;
    public Button DownButton;
    public GameObject FPlayer;
    public GameObject BPlayer;
    public GameObject LPlayer;
    public GameObject RPlayer;
    public GameObject UnderWood;
    public GameObject Quiz;
    public GameObject Wrong;
    public GameObject Correct;

    public Button Left;
    public Button Right;

    Vector3 moveVelocity = Vector3.zero;

    public float moveSpeed = 5.0f;

    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool isPossibleClicked = true;

    private bool isCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            Vector3 camerapos = mainCamera.transform.position;

            moveVelocity = new Vector3(0, 1f, 0);

            mainCamera.transform.position += moveVelocity * moveSpeed * Time.deltaTime;

            FPlayer.SetActive(false);
            BPlayer.SetActive(true);
            LPlayer.SetActive(false);
            RPlayer.SetActive(false);

            Debug.Log(mainCamera.transform.position);
            Debug.Log(mainCamera.transform.position.y);

        }

        if (isDown)
        {
            Vector3 camerapos = mainCamera.transform.position;

            moveVelocity = new Vector3(0, -1f, 0);

            mainCamera.transform.position += moveVelocity * moveSpeed * Time.deltaTime;

            FPlayer.SetActive(true);
            BPlayer.SetActive(false);
            LPlayer.SetActive(false);
            RPlayer.SetActive(false);

        }

        if (isLeft)
        {
            Vector3 camerapos = mainCamera.transform.position;

            moveVelocity = new Vector3(-1f, 0, 0);

            mainCamera.transform.position += moveVelocity * moveSpeed * Time.deltaTime;

            FPlayer.SetActive(false);
            BPlayer.SetActive(false);
            LPlayer.SetActive(true);
            RPlayer.SetActive(false);

        }

        if (isRight)
        {
            Vector3 camerapos = mainCamera.transform.position;

            moveVelocity = new Vector3(1f, 0, 0);

            mainCamera.transform.position += moveVelocity * moveSpeed * Time.deltaTime;

            FPlayer.SetActive(false);
            BPlayer.SetActive(false);
            LPlayer.SetActive(false);
            RPlayer.SetActive(true);

        }

        if (!isCheck)
        {
            if (mainCamera.transform.position.y > 70.66)
            {
                Debug.Log("On");
                isCheck = true;
                UnderWood.SetActive(true);
                isPossibleClicked = false;
            }
        }
        
    }

    public void ClickUp ()
    {
        if (isPossibleClicked)
        {
            isUp = true;
        }
        
    }

    public void UnPressUp()
    {
        isUp = false;
    }

    public void ClickDown()
    {
        if (isPossibleClicked)
        {
            isDown = true;
        }
    }

    public void UnPressDown()
    {
        isDown = false;
    }

    public void ClickLeft()
    {
        if (isPossibleClicked)
        {
            isLeft = true;
        }
    }

    public void UnPressLeft()
    {
        isLeft = false;
    }

    public void ClickRight()
    {
        if (isPossibleClicked)
        {
            isRight = true;
        }
        
    }

    public void UnPressRight()
    {
        isRight = false;
    }

    public void ClickUnderExit()
    {
        isCheck = false;
        UnderWood.SetActive(false);
    }

    public void QuizExit()
    {
        isCheck = false;
        Quiz.SetActive(false);
    }

    public void ClickQuiz()
    {
        UnderWood.SetActive(false);
        Quiz.SetActive(true);
    }

    public void ClickWrongAns()
    {
        Left.interactable = false;
        Right.interactable = false;
        Wrong.SetActive(true);
        Invoke("InactiveWrong", 3f);
    }

    public void ClickCorrectAns()
    {
        Left.interactable = false;
        Right.interactable = false;
        Correct.SetActive(true);
        Invoke("InactiveCorrect", 3f);
    }

    private void InactiveWrong()
    {
        Left.interactable = true;
        Right.interactable = true;
        Wrong.SetActive(false);
    }

    private void InactiveCorrect()
    {
        Left.interactable = true;
        Right.interactable = true;
        Correct.SetActive(false);
        Quiz.SetActive(false);
        isPossibleClicked = true;
    }
}
