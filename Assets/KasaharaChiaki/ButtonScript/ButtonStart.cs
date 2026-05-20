using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void StartGame(string loodScene)
    {
        SceneManager.LoadScene(loodScene);
    }
}