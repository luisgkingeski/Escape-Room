using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : SingletonMonobehaviour<Puzzle1>
{
    public List<GameObject> piecesList;
    public GameObject pieces;
    public float speed = 2f;
    private bool camMove = true;

    void Start()
    {
        piecesList = new List<GameObject>();

        int i = 1;
        foreach (Transform child in pieces.transform.GetChild(0).transform)
        {
            child.gameObject.name = i.ToString();
            piecesList.Add(child.gameObject);
            i++;
        }
        piecesList[i - 2].gameObject.name = "0";
    }

    public void MovePiece(int index)
    {
        if (camMove)
        {
            GameObject target = piecesList[index - 1];
            Pieces targetPiece = target.GetComponent<Pieces>();

            Vector3 auxPos = target.transform.position;
            int auxIndex = targetPiece.indexInBoard;

            GameObject empty = piecesList[piecesList.Count - 1];
            Pieces emptyPiece = empty.GetComponent<Pieces>();

            targetPiece.indexInBoard = emptyPiece.indexInBoard;
            emptyPiece.indexInBoard = auxIndex;

            StartCoroutine(StartMovePiece(target, target.transform.position, empty.transform.position));
            StartCoroutine(MoveEmptyPiece(empty, empty.transform.position, auxPos));
        }
     
    }

    IEnumerator StartMovePiece(GameObject target, Vector3 start, Vector3 destiny)
    {
        camMove = false;
        var t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * speed;

            if (t > 1)
            {
                t = 1;
            }

            target.transform.position = Vector3.Lerp(start, destiny, t);

            yield return null;
        }
        camMove = true;
    }

    IEnumerator MoveEmptyPiece(GameObject target, Vector3 start, Vector3 destiny)
    {
        var t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * speed;

            if (t > 1)
            {
                t = 1;
            }

            target.transform.position = Vector3.Lerp(start, destiny, t);

            yield return null;
        }
    }

}
