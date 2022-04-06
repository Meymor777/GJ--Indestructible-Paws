using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public static GameControler Instance;
    public GameObject CatWarrior;
    public Transform teleport;

    public static bool GameStarted { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        GameStarted = true;
        Field2048.Instance.GenerateField();
    }
    public void Win()
    {
        GameObject BombIns = Instantiate(CatWarrior, teleport.position, teleport.rotation);
    }
    public void Lose()
    {
        GameStarted = false;
        SceneManager.LoadScene(3);
    }

}
