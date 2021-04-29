using UnityEngine;

public class Puzzle3 : SingletonMonobehaviour<Puzzle3>
{
    public MeshRenderer pointSphere;
    public Perspective perspective;
    public bool win = false;

    public void Win()
    {
        pointSphere.material.EnableKeyword("_EMISSION");
        perspective.enabled = false;
        win = true;
    }
}
