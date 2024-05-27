using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField] private string infiniteGameSceneName = "Infinite Gamemode";

    public void NewGameButton()
    {
        SceneManager.LoadScene(infiniteGameSceneName);
    }
}
