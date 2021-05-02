using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region References

    public GameObject pauseMenu;
    private Scene scene;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 1)
        {
            pauseMenu.SetActive(false);
        }
    }

    #endregion

    #region Private Methods

    private void FixedUpdate()
    {
        if (scene.buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    #endregion

    #region Public Methods

    public void BtnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void BtnContinue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    #endregion
}
