using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // Referensi ke Transform pemain
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("pengguna").transform;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Mengatur tujuan NavMesh Agent ke posisi pemain
            navMeshAgent.SetDestination(target.position);


        }
    }
}
