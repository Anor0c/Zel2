using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
  public void ToGameplay()
    {
        SceneManager.LoadScene(0);
    }
}
