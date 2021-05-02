using System.Collections;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    #region Variables

    private bool coroutineAllowed;
    public int numberShown;

    #endregion

    #region References

    private SoundManager soundManager;
    private Puzzle4 p;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
        soundManager = SoundManager.Instance;
        p = Puzzle4.Instance;
    }

    private void OnMouseDown()
    {
        if (!p.win)
        {
            if (coroutineAllowed)
            {
                StartCoroutine("RotateWheel");
            }
        }
    }

    #endregion

    #region Coroutines

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;
        soundManager.PlayPuzzle4Sound();
        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 3f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 9)
        {
            numberShown = 0;
        }
        Puzzle4.Instance.UpdatePad(gameObject.name, numberShown);
    }

    #endregion
}
