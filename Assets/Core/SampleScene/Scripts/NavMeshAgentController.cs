using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentController : MonoBehaviour {


    public Action OnReachDestination;

    private NavMeshAgent m_navMeshAgent;
    private int m_areaMask;
    private bool m_reachDestination;

    private void Awake()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_areaMask = m_navMeshAgent.areaMask;
    }


    public void SetDestination(Vector3 destination)
    {
        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(destination, out navMeshHit, 2f, m_areaMask);

        if (!navMeshHit.hit)
            return;

        m_reachDestination = false;

        m_navMeshAgent.SetDestination(navMeshHit.position);

        StopCoroutine(CheckDestination());
        StartCoroutine(CheckDestination());
    }

    private IEnumerator CheckDestination()
    {
        while (!m_reachDestination)
        {
            if (!m_navMeshAgent.pathPending)
            {
                if (m_navMeshAgent.remainingDistance <= m_navMeshAgent.stoppingDistance)
                {
                    if (!m_navMeshAgent.hasPath || Math.Abs(m_navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                    {
                        m_reachDestination = true;
                        if (OnReachDestination != null)
                            OnReachDestination();
                    }
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
