using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopup : MonoBehaviour
{
    public GameObject gamePopup;

    public void GamePopup()
    {
        gamePopup.SetActive(true);
    }
}
