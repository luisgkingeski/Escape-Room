using System.Collections;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public int pieceIndex;
    public LayerMask layerMask;
    public bool canMove = false;
    private Puzzle1 p;
    private void Start()
    {
        p = Puzzle1.Instance;
        StartCoroutine(GetIndex());
    }


    private void Update()
    {
        if (pieceIndex != 0)
        {
            canMove = false;
            Raycasts();
        }
    }

    private void Raycasts()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 100, layerMask))
        {
            if (hit.transform.gameObject.name == "0")
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }

        if (canMove)
        {
            return;
        }

        if (Physics.Raycast(transform.position, -transform.up, out hit, 100, layerMask))
        {
            if (hit.transform.gameObject.name == "0")
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }

        if (canMove)
        {
            return;
        }

        if (Physics.Raycast(transform.position, transform.right, out hit, 100, layerMask))
        {
            if (hit.transform.gameObject.name == "0")
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }

        if (canMove)
        {
            return;
        }

        if (Physics.Raycast(transform.position, -transform.right, out hit, 100, layerMask))
        {
            if (hit.transform.gameObject.name == "0")
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }
    }

    IEnumerator GetIndex()
    {
        yield return new WaitForSeconds(0.1f);
        pieceIndex = int.Parse(gameObject.name);
    }

    private void OnMouseDown()
    {
        if (canMove)
        {
            p.MovePiece(pieceIndex);
        }
    }
}
