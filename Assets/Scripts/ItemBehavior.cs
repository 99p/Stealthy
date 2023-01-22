using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player"){
            Destroy(this.transform.parent.gameObject);
            Debug.Log("<color=yellow>Item collected!</color>");
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
