using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public void Close()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
