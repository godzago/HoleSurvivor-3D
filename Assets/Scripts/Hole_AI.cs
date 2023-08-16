using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hole_AI : MonoBehaviour
{
    public float minX = -6f; // AI'n�n sol s�n�r�
    public float maxX = 6f; // AI'n�n sa� s�n�r�
    public float minZ = -6f; // AI'n�n alt s�n�r�
    public float maxZ = 6f; // AI'n�n �st s�n�r�

    private NavMeshAgent navMeshAgent; // AI'n�n NavMeshAgent bile�eni


    void Start()
    {
        // NavMeshAgent bile�enini al
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // E�er hedefe ula��lm��sa yeni hedef belirle
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f && PlayerPrefs.GetInt("GameStart") == 1)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        // Rastgele bir hedef belirle
        Vector3 randomDestination = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));

        // Hedefi ayarla
        navMeshAgent.SetDestination(randomDestination);
    }
}
