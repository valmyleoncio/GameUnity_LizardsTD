using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public Text MoneyUI;
    public static int Lives;
    public static int startLives = 3;
    public static int Rounds;
    public List<RawImage> hearts;
    public Texture heartBlack;

    private void Start() {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }

    private void Update() {
        MoneyUI.text = Money.ToString();
        if(Lives == 2)
            hearts[0].texture = heartBlack;

        else if(Lives == 1){
            hearts[0].texture = heartBlack;
            hearts[1].texture = heartBlack;
        }
           
        else if(Lives == 0){
            hearts[0].texture = heartBlack;
            hearts[1].texture = heartBlack;
            hearts[2].texture = heartBlack;
        }
    }
}
