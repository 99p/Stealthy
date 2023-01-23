using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;
    public string State{
        get { return _state; }
        set { _state = value; }
    }

    public string labelText = "4つのアイテムを集めて自由を勝ち取ろう！";
    public int maxItems = 4;
    
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    
    public Stack<string> lootStack = new Stack<string>();
    
    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

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
    
    private void OnGUI() {
        GUI.Box(new Rect(20, 20, 150, 25), $"Player's HP: {_playerHP}");
        GUI.Box(new Rect(20, 50 ,150, 25), $"集めたアイテム: {_itemsCollected}");
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen){
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "You WIN!!")){
                Utilities.RestartLevel(0);
            };
        }
        if(showLossScreen){
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "U Lose!!")){
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("レベルの再開に成功!!");
                }
                catch(System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug($"シーンを0にします:{e.ToString()}");
                }
                finally
                {
                    debug("リスタートを処理しました。");
                }
            }
        }
    }
    
    private void Start() {
        Initialize();
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);
    }
    
    public void Initialize(){
        _state = "Managerの初期化を終えました";
        _state.FancyDebug();
        debug(_state);
        LogWithDelegate(debug);
        
        GameObject player = GameObject.Find("Player");
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;
        
        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
    }
    
    public void HandlePlayerJump(){
        debug("プレイヤーがジャンプした！！！！！");
    }
    
    public void PrintLootReport(){
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        Debug.Log($"{currentItem}をGET!! Next{nextItem}");
        Debug.Log($"お宝が{lootStack.Count}つ君を待っているぞ！");
    }
    
    public static void Print(string newText){
        Debug.Log(newText);
    }
    
    public void LogWithDelegate(DebugDelegate del){
        del("デバッグ出力を委任する");
    }
}
