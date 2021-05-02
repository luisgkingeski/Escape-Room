using UnityEngine;

public class Puzzle4 : SingletonMonobehaviour<Puzzle4>
{
    #region Variables

    private int[] result, correctCombination;
    public bool win = false;

    #endregion

    #region References

    public Wheel wheel1;
    public Wheel wheel2;
    public Wheel wheel3;
    public Wheel wheel4;
    public MeshRenderer pointSphere;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        result = new int[] { 0, 0, 0, 0 };
        correctCombination = new int[] { 5, 1, 7, 3 };
    }

    #endregion

    #region Public Methods

    public void UpdatePad(string name, int value)
    {
        switch (name)
        {
            case "WheelOne":
                result[0] = value;
                break;

            case "WheelTwo":
                result[1] = value;
                break;

            case "WheelThree":
                result[2] = value;
                break;

            case "WheelFour":
                result[3] = value;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
           && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            pointSphere.material.EnableKeyword("_EMISSION");
            win = true;
            ChangeCamera.Instance.StartReturnPOV();
        }
    }

    #endregion
}
