using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpin : MonoBehaviour
{
    public GameObject lockPW;
    public Text passwordInput;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Tag : {other.tag}");
        if (Input.GetMouseButtonDown(1))
        {
            lockPW.SetActive(true);
            CameraMove.instance.isTurn = false;
        }
    }

    public void InputText(int val)
    {
        passwordInput.text += val.ToString();
    }

    public void Clear()
    {
        passwordInput.text = "";
    }

    public void Check()
    {

    }

    public void ExitUI()
    {
        lockPW.SetActive(false);
        CameraMove.instance.isTurn = true;
    }
}
