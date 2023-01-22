using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;

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
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute(){
        foreach(Transform child in patrolRoute){
            locations.Add(child);
        }
    }
    
    void MoveToNextPatrolLocation(){
        agent.destination = locations[locationIndex].position;
    }
}
