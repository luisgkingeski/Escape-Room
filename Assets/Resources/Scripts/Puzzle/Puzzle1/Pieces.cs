using System.Collections;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    #region Variables

    public int pieceIndex;
    public int indexInBoard;
    public bool canMove = false;

    #endregion

    #region References

    public LayerMask layerMask;
    private Puzzle1 p;

    #endregion

    #region MonoBehaviour Callbacks

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


    private void OnMouseDown()
    {
        if (canMove && !p.win)
        {
            p.MovePiece(pieceIndex);
        }
    }

    #endregion

    #region Private Methods

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

    #endregion

    #region Coroutines

    IEnumerator GetIndex()
    {
        yield return new WaitForSeconds(0.1f);
        pieceIndex = int.Parse(gameObject.name);
        indexInBoard = pieceIndex;
    }

    #endregion
}
