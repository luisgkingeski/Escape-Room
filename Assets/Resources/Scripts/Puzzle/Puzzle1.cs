using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : SingletonMonobehaviour<Puzzle1>
{
    public List<GameObject> piecesList;
    public GameObject pieces;
    public float speed = 2f;
    
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
        GameObject target = piecesList[index - 1];
        Vector3 aux = target.transform.position;
        GameObject empty = piecesList[piecesList.Count - 1];


        StartCoroutine(StartMovePiece(target, target.transform.position, empty.transform.position));
        StartCoroutine(MoveEmptyPiece(empty, empty.transform.position, aux));
    }

    IEnumerator StartMovePiece(GameObject target, Vector3 start, Vector3 destiny)
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
