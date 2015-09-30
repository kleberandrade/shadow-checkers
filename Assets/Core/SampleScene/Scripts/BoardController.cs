using UnityEngine;
using CheckerEngine;
using CheckerEngine.Player;
using System;
using CheckerEngine.Core;

public class BoardController : Singleton<BoardController>
{

    private CheckerCore m_CheckerCore;

    private IPlayer m_PlayerWhite;
    private IPlayer m_PlayerBlack;

    [SerializeField]
    private GameObject playerWhitePrefab;

    [SerializeField]
    private GameObject playerBlackPrefab;

    private PawnBase selectedPawn;
    private CellBase[][] cellsGrid;

    private void Awake()
    {
        m_PlayerWhite = new HumanPlayer(Team.White);
        m_PlayerBlack = new HumanPlayer(Team.Black);

        m_CheckerCore = new CheckerCore(m_PlayerWhite, m_PlayerBlack);
        m_CheckerCore.OnNewPlayersTurn += M_CheckerCore_OnNewPlayersTurn;

        InstantiatePawns();

        SetupCellsGrid();
    }


    private void InstantiatePawns()
    {
        // instanciate pawns and do necessary associations
        for (int i = 0; i < m_PlayerWhite.Pieces.Length; i++)
        {
            Vector3 position = new Vector3(m_PlayerWhite.Pieces[i].Position.Col, 0, m_PlayerWhite.Pieces[i].Position.Row);
            (Instantiate(playerWhitePrefab, position, Quaternion.identity) as GameObject).GetComponent<PawnBase>().Pawn = m_PlayerWhite.Pieces[i];

            position = new Vector3(m_PlayerBlack.Pieces[i].Position.Col, 0, m_PlayerBlack.Pieces[i].Position.Row);
            (Instantiate(playerBlackPrefab, position, Quaternion.identity) as GameObject).GetComponent<PawnBase>().Pawn = m_PlayerBlack.Pieces[i];
        }
    }


    private void SetupCellsGrid()
    {
        // setup cells grid reference
        cellsGrid = new CellBase[8][];
        for (int i = 0; i < 8; i++)
            cellsGrid[i] = new CellBase[8];

        CellBase[] existingCells = GetComponentsInChildren<CellBase>();
        foreach (var cell in existingCells)
        {
            int col = (int)cell.transform.position.x;
            int row = (int)cell.transform.position.z;
            cellsGrid[col][row] = cell;
        }
    }


    // Search for every possible destiny and highlight it
    internal void HighlighAvailableMoves(ICheckerPiece pawn)
    {
        Move[] possibleMoves = pawn.CandidatesMoves();

        foreach (var move in possibleMoves)
        {
            if (move.MoveType == MoveType.SimpleMove)
                cellsGrid[move.Destiny.Col][move.Destiny.Row].SetAsPossibleDestination();
            if (move.MoveType == MoveType.CaptureMove)
                cellsGrid[move.Destiny.Col][move.Destiny.Row].SetAsKillPawnDestination();
        }
    }

    // Search for every possible destiny and unhighlight it
    internal void UnhighlightAvailableMoves(ICheckerPiece pawn)
    {
        Move[] possibleMoves = pawn.CandidatesMoves();
        foreach (var move in possibleMoves)
            cellsGrid[move.Destiny.Col][move.Destiny.Row].SetAsNormal();
    }

    internal void TrySelect(PawnBase pawnBase)
    {
        if (pawnBase.Pawn.Team == m_CheckerCore.CurrentTurnPlayer)
        {
            if (selectedPawn != null)
                selectedPawn.Unselect();
            pawnBase.Select();
            selectedPawn = pawnBase;
        }
        else
        {
            Debug.Log("Vez do jogador: " + m_CheckerCore.CurrentTurnPlayer);
        }
    }

    private void M_CheckerCore_OnNewPlayersTurn(object sender, CheckerEngine.Core.EventArgs.NewTurnEventArgs e)
    {
        Debug.Log("Vez do jogador: " + e.CurrentPlayer);
    }

    void Start () {
        m_CheckerCore.StartNewGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
