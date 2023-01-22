using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player"){
            Debug.Log("<color=red>Attack!!!!</color>");
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if(other.name == "Player"){
            Debug.Log("<color=gray>No Problem...</color>");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
