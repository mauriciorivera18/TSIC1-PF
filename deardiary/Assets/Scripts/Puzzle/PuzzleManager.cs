using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    private int correctPieces = 0;
    public int totalPieces = 9;
    public GameObject winText;
    public Transform piecesContainer;

    private void Awake()
    {
        Instance = this;
    }

    public void PiecePlacedCorrectly()
    {
        correctPieces++;
        if (correctPieces == totalPieces)
        {
            winText.SetActive(true);
        }
    }

    public void RestartPuzzle()
    {
        correctPieces = 0;
        winText.SetActive(false);

        foreach (Transform piece in piecesContainer)
        {
            Vector3 randomPos = new Vector3(Random.Range(-5f, -3f), 0, Random.Range(-1f, 1f));
            piece.position = randomPos;
            piece.GetComponent<DragAndDrop>().enabled = true;
        }
    }
}
