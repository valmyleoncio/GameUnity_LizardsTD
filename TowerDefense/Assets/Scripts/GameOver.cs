using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour{
    public Text roundsText;

    private void OnEnable() {
        roundsText.text = PlayerStats.Rounds.ToString();    
    }

    public void retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu(){
        Debug.Log("Go to menu."); 
    }
}
