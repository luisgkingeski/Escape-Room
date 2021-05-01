using System.Collections;
using UnityEngine;

public class Puzzle2 : SingletonMonobehaviour<Puzzle2>
{
    public ColorPieces red;
    public ColorPieces blue;
    public ColorPieces yellow;

    public int selectedAmount = 0;
    public int resultIndex = 1;

    public MeshRenderer pointSphere1;
    public MeshRenderer pointSphere2;
    public MeshRenderer pointSphere3;
    public MeshRenderer result;

    public Material orange, green, purple;

    public bool win = false;

    private SoundManager soundManager;

    void Start()
    {
        result.material = orange;
        soundManager = SoundManager.Instance;
    }

    private void ResetColors()
    {
        red.ResetColor();
        blue.ResetColor();
        yellow.ResetColor();
        selectedAmount = 0;
    }


    public void Select()
    {
        selectedAmount++;

        if (selectedAmount == 2)
        {
            if (resultIndex == 1)
            {
                StartCoroutine(CheckOrange());
            }
            else if (resultIndex == 2)
            {
                StartCoroutine(CheckGreen());
            }
            else if (resultIndex == 3)
            {
                StartCoroutine(CheckPurple());
            }

        }

    }

    IEnumerator CheckOrange()
    {

        if (red.selected && !blue.selected && yellow.selected)
        {
            pointSphere1.material.EnableKeyword("_EMISSION");
            result.material = green;
            resultIndex = 2;
        }
      
        yield return new WaitForSeconds(1);
        ResetColors();

        soundManager.PlayPuzzle2SoundFail();

    }

    IEnumerator CheckGreen()
    {
        if (!red.selected && blue.selected && yellow.selected)
        {
            pointSphere2.material.EnableKeyword("_EMISSION");
            result.material = purple;
            resultIndex = 3;
        }

        yield return new WaitForSeconds(1);
        ResetColors();

        soundManager.PlayPuzzle2SoundFail();
    }

    IEnumerator CheckPurple()
    {
        if (red.selected && blue.selected && !yellow.selected)
        {
            pointSphere3.material.EnableKeyword("_EMISSION");
            ChangeCamera.Instance.StartReturnPOV();
            win = true;
        }

        yield return new WaitForSeconds(1);
        ResetColors();

        soundManager.PlayPuzzle2SoundFail();
    }




}
