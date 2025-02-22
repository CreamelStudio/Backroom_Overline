using UnityEngine;

public class PaperManager : MonoBehaviour
{
    public int countPw;
    public GameObject pwObj;
    public GameObject[] passwordObjs;
    public GameObject[] spawnPW;

    private void Start()
    {
        int tempRandom = Random.Range(0, spawnPW.Length);
        Instantiate(pwObj, spawnPW[tempRandom].transform.position + new Vector3(0, 0.4f, 0), new Quaternion(0, 0, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            Destroy(other.gameObject);
            passwordObjs[countPw].SetActive(true);
            countPw++;
            int tempRandom = Random.Range(0, spawnPW.Length);
            if(countPw != passwordObjs.Length - 1)Instantiate(pwObj, spawnPW[tempRandom].transform.position + new Vector3(0, 0.4f, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}
