using UnityEngine.SceneManagement;

namespace Classes.UI
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