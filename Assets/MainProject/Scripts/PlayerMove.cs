using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float RunmoveSpeed;
    public Rigidbody rb;

    public bool isMove;
    public bool isRun;

    public GameObject keypad;

    public GameObject bigLight;
    public Image lightCoolBack;
    
    public bool isCanUseLight;
    public AudioClip cameraShut;
    private Vector3 movement;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && isCanUseLight && !keypad.activeSelf)
        {
            lightCoolBack.fillAmount = 0;
            isCanUseLight = false;
            AudioManager.instance.PlayOnceSound(cameraShut);
            bigLight.SetActive(true);
            StartCoroutine(LightOff());
        }

        if (movement == Vector3.zero)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dead"))
        {
            FindAnyObjectByType<Roland>().Dead();
        }
    }

    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.LeftShift)) {
            rb.MovePosition(rb.position + transform.TransformDirection(movement) * (RunmoveSpeed * Time.deltaTime));
            isRun = true;
        }
        else{
            isRun = false;
            rb.MovePosition(rb.position + transform.TransformDirection(movement) * (moveSpeed * Time.deltaTime));
        }
        
    }

    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(0.1f);
        bigLight.SetActive(false);
        DOTween.To(() => lightCoolBack.fillAmount, x => lightCoolBack.fillAmount = x, 1f, 3);
        yield return new WaitForSeconds(3);
        isCanUseLight = true;
    }
}