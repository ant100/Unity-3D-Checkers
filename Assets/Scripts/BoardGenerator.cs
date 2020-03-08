using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private int boardSize = 8;
    [SerializeField] private GameObject blackTilePrefab = null;
    [SerializeField] private GameObject whiteTilePrefab = null;
    [SerializeField] private GameObject blackPiecePrefab = null;
    [SerializeField] private GameObject whitePiecePrefab = null;
    [SerializeField] private Transform piecesParent = null;

    private void Start()
    {
        GenerateBoard();
        GeneratePieces();
    }

    private void GenerateBoard()
    {
        GameObject currentTile = null;

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                // set black or white tile
                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    currentTile = blackTilePrefab;
                else
                    currentTile = whiteTilePrefab;

                // instantiate prefab
                GameObject newTile = Instantiate(currentTile, transform);
                newTile.transform.localPosition = new Vector3(i, 0, j);
            }
        }
    }

    private void GeneratePieces()
    {
        //GameObject currentPiece = null;
        int numRows = (boardSize - 2) / 2;
        int numCols = boardSize / 2;
        int numWhitePieces = 0;
        int numBlackPieces = 0;

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                // this means we are on a black tile
                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                {
                    // we do the white team first
                    if (numWhitePieces < numRows * numCols)
                    {
                        // if we are on an even col
                        if (i % 2 == 0)
                        {
                            // we should instantiate on even tiles
                            if (j % 2 == 0)
                            {
                                numWhitePieces++;
                                GameObject newPiece = Instantiate(whitePiecePrefab, piecesParent);
                                newPiece.transform.localPosition = new Vector3(j, 0.1f, i);
                            }
                        }
                        // uneven col
                        else
                        {
                            // we should instantiate on uneven tiles
                            if (j % 2 != 0)
                            {
                                numWhitePieces++;
                                GameObject newPiece = Instantiate(whitePiecePrefab, piecesParent);
                                newPiece.transform.localPosition = new Vector3(j, 0.1f, i);
                            }
                        }
                    }
                    // now we do the black team, for this we have to do two rows after the white team
                    else
                    {
                        if (numBlackPieces < numRows * numCols)
                        {
                            // if we are on an even col
                            if (i % 2 == 0)
                            {
                                // we should instantiate on even tiles
                                if (j % 2 == 0)
                                {
                                    numBlackPieces++;
                                    GameObject newPiece = Instantiate(blackPiecePrefab, piecesParent);
                                    newPiece.transform.localPosition = new Vector3(j, 0.1f, i+2);
                                }
                            }
                            // uneven col
                            else
                            {
                                // we should instantiate on uneven tiles
                                if (j % 2 != 0)
                                {
                                    numBlackPieces++;
                                    GameObject newPiece = Instantiate(blackPiecePrefab, piecesParent);
                                    newPiece.transform.localPosition = new Vector3(j, 0.1f, i+2);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
