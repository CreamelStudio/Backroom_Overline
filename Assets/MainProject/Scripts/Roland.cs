using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Roland : MonoBehaviour
{
    public Transform target;
    public PlayerMove move;

    public Transform[] points;
    public int nowGoPoint;

    public GameObject rolandCamera;
    public AudioClip shoutAudioClip;

    public bool isCanMove;

    NavMeshAgent nmAgent;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    public void Dead()
    {
        Camera.main.enabled = false;
        rolandCamera.SetActive(true);
        rolandCamera.GetComponent<Camera>().enabled = true;
        AudioManager.instance.PlayOnceSound(shoutAudioClip);
        Invoke("RestartGame", 2);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dead();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            nowGoPoint = Random.Range(0, points.Length);
            nmAgent.SetDestination(points[nowGoPoint].position);
        }

        if (other.gameObject.CompareTag("BigLight"))
        {
            isCanMove = false;
            StartCoroutine(StopLightRoland());
        }
        if (other.gameObject.CompareTag("Lights") && isCanMove)
        {
            StopAllCoroutines();
            nmAgent.SetDestination(target.position);
        }
        else if (other.gameObject.CompareTag("SmallC") && isCanMove && move.isMove)
        {
            StopAllCoroutines();
            nmAgent.SetDestination(target.position);
        }
        else if (other.gameObject.CompareTag("BigC") && isCanMove)
        {
            if (move.isRun && move.isMove)
            {
                StopAllCoroutines();
                nmAgent.SetDestination(target.position);
            }
        }
        else if(isCanMove)
        {
            StartCoroutine(StopRoland());
        }
    }


    IEnumerator StopRoland()
    {
        yield return new WaitForSeconds(3);
        nmAgent.SetDestination(points[nowGoPoint].position);
    }

    IEnumerator StopLightRoland()
    {
        nmAgent.SetDestination(transform.position);
        yield return new WaitForSeconds(1);
        isCanMove = true;
    }


}