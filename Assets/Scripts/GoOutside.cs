using UnityEngine;
using UnityEngine.SceneManagement;
public class GoOutside : MonoBehaviour
{
    public string OutScene;
    public void ChangeScene()
    {
        SceneManager.LoadScene("OutScene");
    }
}
