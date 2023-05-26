using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHaksool : MonoBehaviour
{
    public void ChangeScene(string InScene)
    {
        SceneManager.LoadScene("InScene");
    }

}
