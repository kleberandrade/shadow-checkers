using CheckerEngine.Core;
using System;
using UnityEngine;


[RequireComponent(typeof(NavMeshAgentController))]
public class PawnBase : MonoBehaviour
{

    private NavMeshAgentController m_navMeshAgentController;

    [SerializeField]
    private Material normalMaterial;

    [SerializeField]
    private Material selectedMaterial;

    public CheckerEngine.Core.ICheckerPiece Pawn;


    private void Awake()
    {
        m_navMeshAgentController = GetComponent<NavMeshAgentController>();
    }

    private void Start()
    {

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

    }

    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider
    public void OnMouseDown()
    {
        BoardController.Instance.TrySelect(this);
    }

    internal void Select()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
            r.material = selectedMaterial;
        BoardController.Instance.HighlighAvailableMoves(Pawn);
    }

    internal void Unselect()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
            r.material = normalMaterial;

        BoardController.Instance.UnhighlightAvailableMoves(Pawn);
    }
}
