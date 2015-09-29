using UnityEngine;


[RequireComponent(typeof(NavMeshAgentController))]
public class PawnBase : MonoBehaviour {

    private NavMeshAgentController m_navMeshAgentController;

    private void Awake()
    {
        m_navMeshAgentController = GetComponent<NavMeshAgentController>();
    }

    private void Start()
    {
        OnReachDestination();
    }

    private void OnEnable()
    {
        m_navMeshAgentController.OnReachDestination += OnReachDestination;
    }

    private void OnDisable()
    {
        m_navMeshAgentController.OnReachDestination -= OnReachDestination;
    }

    private void OnReachDestination()
    {
        Vector3 randomPosition = new Vector3(Random.Range(0, 7), 0, Random.Range(0, 7));
        m_navMeshAgentController.SetDestination(randomPosition);
    }
}
 