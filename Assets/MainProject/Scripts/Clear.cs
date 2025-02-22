using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Stage1");
    }
}
