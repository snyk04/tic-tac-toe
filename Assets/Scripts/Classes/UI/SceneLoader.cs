using UnityEngine.SceneManagement;

namespace TicTacToe.UI
{
    public class SceneLoader
    {
        public void ReloadCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}