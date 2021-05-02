using UnityEngine;
using UnityEngine.UI;

public class MouseLook : SingletonMonobehaviour<MouseLook>
{
    #region Variables

    public float mouseSensitivity = 1;
    public float xRotation = 0f;

    #endregion

    #region References

    public Transform playerBody;
    public Slider slider;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        slider.value = 1;
        UpdateMouseSensitivity();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    #endregion

    #region Public Methods

    public void UpdateMouseSensitivity()
    {
        mouseSensitivity = slider.value;
    }

    #endregion
}
