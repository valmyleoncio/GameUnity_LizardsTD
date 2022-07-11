using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static bool GameIsOver;
    public GameObject gameOverUi;

    public static int contEnemy = 0;
    public static Enemy[] enemies;

    private void Start() {
        GameIsOver = false;
    }

    void Update()
    {
        if(GameIsOver)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame(){
        GameIsOver = true;
        gameOverUi.SetActive(true);
    }

    public static int getEnemyTag(){
        return contEnemy++;
    }
}
