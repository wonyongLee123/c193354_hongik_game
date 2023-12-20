
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Main = 0,
    Game,
    Win,
    Lose
}
public class GameManager
{
    private GameManager()
    { }

    private static GameManager _instance;
    
    public static GameManager Instance
    {
        get{
            if(_instance == null) _instance = new GameManager();
            return _instance;
        }  
    }

    private CameraController cameraController;


    public void Shake()
    {
        if (cameraController == null)
        {
            cameraController = Object.FindObjectOfType<CameraController>();
        }
        cameraController.StartShake();
    }

    public void ChangeScene(Scene scene)
    {
        switch (scene)
        {
            case Scene.Game:
                break;
            case Scene.Main:
                break;
            case Scene.Win:
                SceneManager.LoadScene("Win");
                break;
            case Scene.Lose:
                break;
        }
    }
}
