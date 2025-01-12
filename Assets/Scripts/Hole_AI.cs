using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Hole_AI : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] float minX = -6f;
    [SerializeField] float maxX = 6f;
    [SerializeField] float minZ = -6f;
    [SerializeField] float maxZ = 6f;

    NavMeshAgent navMeshAgent;
    HoleManager holeManager;
    bool enes = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        holeManager = GameObject.Find("HoleDestroyed").GetComponent<HoleManager>();
        StartCoroutine(HoleStart(2));
    }

    void Update()
    {
        if (enes)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f && PlayerPrefs.GetInt("GameState") == 1)
            {
                SetRandomDestination();
            }
        }
    }

    void SetRandomDestination()
    {
        if (holeManager.GameOver == false)
        {
            Vector3 randomDestination = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));
            navMeshAgent.SetDestination(randomDestination);
        }
        else
        {
            navMeshAgent.speed = 0;
        }
    }

    IEnumerator HoleStart(int t)
    {
        yield return new WaitForSeconds(t);
        enes = true;
    }
}
