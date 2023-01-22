using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "4つのアイテムを集めて自由を勝ち取ろう！";
    public int maxItems = 4;
    
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    public int Items {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;
            
            if(_itemsCollected >= maxItems){
                labelText = "アイテムを全部見つけんた！";
                showWinScreen = true;
                Time.timeScale = 0f;
            } else {
                labelText = $"あと{maxItems - _itemsCollected}つ！！！！！";
            }
            
        }
    }
    
    private int _playerHP = 3;
    public int HP {
        get { return _playerHP; }
        set {
            _playerHP = value;
            if(_playerHP <= 0){
                labelText = "One more Life?????";
                showLossScreen = true;
                Time.timeScale = 0f;
            } else {
                labelText = "WOWOOWOooooo!!!!!";
            }
        }
    }
    
    void RestartLevel(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    
    private void OnGUI() {
        GUI.Box(new Rect(20, 20, 150, 25), $"Player's HP: {_playerHP}");
        GUI.Box(new Rect(20, 50 ,150, 25), $"集めたアイテム: {_itemsCollected}");
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen){
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "You WIN!!")){
                RestartLevel();
            };
        }
        if(showLossScreen){
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "U Lose!!")){
                RestartLevel();
            }
        }
    }
}
