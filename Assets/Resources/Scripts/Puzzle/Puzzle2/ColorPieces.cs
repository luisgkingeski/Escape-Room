using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPieces : MonoBehaviour
{

    public bool selected = false;
    [Tooltip ("1 is red, 2 is blue, 3 is yellow")]
    [Range (1,3)]
    public int color;
    private MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.material.DisableKeyword("_EMISSION");
    }

    private void OnMouseDown()
    {        
        rend.material.EnableKeyword("_EMISSION");
        if (!selected)
        {
            selected = true;
            Puzzle2.Instance.Select();
        }        
    }

    public void ResetColor()
    {
        selected = false;
        rend.material.DisableKeyword("_EMISSION");
    }

}
