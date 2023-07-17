using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnClick : MonoBehaviour
{
    //public string nextSceneName;
    private Scene _scene;
   
    private void Awake(){
        _scene=SceneManager.GetActiveScene(); //caching
   
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_scene.buildIndex+1);
    }
}
