using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
