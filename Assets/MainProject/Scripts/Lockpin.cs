using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Lockpin : MonoBehaviour
{
    public GameObject lockPW;
    public Text passwordInput;

    public int pw1;
    public int pw2;
    public int pw3;
    public int pw4;
    public int pw5;
    public int pw6;

    public string password;

    public Text pw1Text;
    public Text pw2Text;
    public Text pw3Text;
    public Text pw4Text;
    public Text pw5Text;
    public Text pw6Text;

    private void Start()
    {
        pw1 = Random.Range(1, 10);
        pw2 = Random.Range(1, 10);
        pw3 = Random.Range(1, 10);
        pw4 = Random.Range(1, 10);
        pw5 = Random.Range(1, 10);
        pw6 = Random.Range(1, 10);
        password = pw1.ToString() + pw2.ToString() + pw3.ToString() + pw4.ToString() + pw5.ToString() + pw6.ToString();

        pw1Text.text = pw1.ToString();
        pw2Text.text = pw2.ToString();
        pw3Text.text = pw3.ToString();
        pw4Text.text = pw4.ToString();
        pw5Text.text = pw5.ToString();
        pw6Text.text = pw6.ToString();
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
            SceneManager.LoadScene("Clear");
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
