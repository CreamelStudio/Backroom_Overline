using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpin : MonoBehaviour
{
    public GameObject lockPW;
    public Text passwordInput;

    public int pw1;
    public int pw2;
    public int pw3;
    public int pw4;

    public string password;

    private void Start()
    {
        pw1 = Random.Range(1, 9);
        pw2 = Random.Range(1, 9);
        pw3 = Random.Range(1, 9);
        pw4 = Random.Range(1, 9);
        password = pw1.ToString() + pw2.ToString() + pw3.ToString() + pw4.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Tag : {other.tag}");

        if (Input.GetMouseButtonDown(1) && other.gameObject.CompareTag("Player"))
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
        if(passwordInput.text == password)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Fail");
        }
    }

    public void ExitUI()
    {
        lockPW.SetActive(false);
        CameraMove.instance.isTurn = true;
    }
}
