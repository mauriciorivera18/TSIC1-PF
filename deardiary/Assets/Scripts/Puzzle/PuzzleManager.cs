using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    private int correctPieces = 0;
    public int totalPieces = 9;
    public Transform piecesContainer;

    private PuzzleUIManager uiManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        uiManager = FindObjectOfType<PuzzleUIManager>();
        if (uiManager == null)
        {
            Debug.LogWarning("PuzzleManager: No se encontró PuzzleUIManager en la escena.");
        }
    }

    public void PiecePlacedCorrectly()
    {
        correctPieces++;
        if (correctPieces == totalPieces)
        {
            Debug.Log("PuzzleManager: Puzzle completo.");
            if (uiManager != null)
                uiManager.ShowWinPanel();
        }
    }

    public void RestartPuzzle()
    {
        correctPieces = 0;

        if (uiManager != null)
            uiManager.HideWinPanel();

        foreach (Transform piece in piecesContainer)
        {
            Vector3 randomPos = new Vector3(Random.Range(-5f, -3f), 0, Random.Range(-1f, 1f));
            piece.position = randomPos;
            piece.GetComponent<DragAndDrop>().enabled = true;
        }
    }
}
