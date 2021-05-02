using UnityEngine;

public class ColorPieces : MonoBehaviour
{
    #region Variables

    public bool selected = false;

    #endregion

    #region References

    private Animator anim;
    private Puzzle2 p;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        anim = GetComponent<Animator>();
        p = Puzzle2.Instance;
    }

    private void OnMouseDown()
    {
        if (!p.win)
        {
            if (!selected)
            {
                SoundManager.Instance.PlayPuzzle2SoundClick();
                anim.SetBool("Fail", false);
                anim.SetBool("Pressed", true);
                selected = true;
                Puzzle2.Instance.Select();
            }
        }
    }

    #endregion

    #region Public Methods

    public void ResetColor()
    {
        selected = false;
        anim.SetBool("Pressed", false);
        anim.SetBool("Fail", true);
    }

    #endregion
}
