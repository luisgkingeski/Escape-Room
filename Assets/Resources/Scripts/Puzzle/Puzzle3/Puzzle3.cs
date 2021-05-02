using UnityEngine;

public class Puzzle3 : SingletonMonobehaviour<Puzzle3>
{
    #region Variables

    public bool win = false;

    #endregion

    #region References

    public MeshRenderer pointSphere;
    public Perspective perspective;

    #endregion

    #region Public Methods

    public void Win()
    {
        pointSphere.material.EnableKeyword("_EMISSION");
        perspective.enabled = false;
        win = true;
    }

    #endregion
}
