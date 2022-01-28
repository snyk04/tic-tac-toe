using UnityEngine;

namespace TicTacToe.UI
{
    public class SceneLoaderComponent : MonoBehaviour
    {
        public SceneLoader SceneLoader { get; private set; }


        private void Awake()
        {
            SceneLoader = new SceneLoader();
        }
        
        public void ReloadCurrentScene()
        {
            SceneLoader.ReloadCurrentScene();
        }
    }
}