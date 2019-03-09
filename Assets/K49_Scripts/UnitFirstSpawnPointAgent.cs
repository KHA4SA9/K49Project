using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitFirstSpawnPointAgent : MonoBehaviour {

    public NavMeshAgent UnitAgent;

    void OnEnable () {

        UnitAgent = gameObject.GetComponent<NavMeshAgent>();
        UnitAgent.SetDestination(MainBuilding.MainBuildingFirstSpawnPoint);
    }
}
