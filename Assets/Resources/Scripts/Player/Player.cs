using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : SingletonMonobehaviour<Player>
{
    #region Variables

    public float speed = 12f;
    public float gravity = -9.81f;
    private bool win = false;
    private Vector3 velocity;
    private bool doorAux = false;
    #endregion

    #region References

    public CharacterController controller;
    public GameObject mainCamera;
    private ChangeCamera changeCamera;
    public LayerMask puzzleLayers;
    public LayerMask doorLayer;
    public GameObject interactTxt;
    public GameObject backTxt;
    public GameObject winTxt;
    private Puzzle1 puzzle1;
    private Puzzle2 puzzle2;
    private Puzzle3 puzzle3;
    private Puzzle4 puzzle4;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        changeCamera = ChangeCamera.Instance;
        interactTxt.SetActive(false);
        backTxt.SetActive(false);
        winTxt.SetActive(false);

        puzzle1 = Puzzle1.Instance;
        puzzle2 = Puzzle2.Instance;
        puzzle3 = Puzzle3.Instance;
        puzzle4 = Puzzle4.Instance;

    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 10, doorLayer) && win)
        {
            winTxt.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            winTxt.SetActive(false);
        }

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 5, puzzleLayers))
        {
            interactTxt.SetActive(true);
        }
        else
        {
            interactTxt.SetActive(false);
        }

        if (mainCamera.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            backTxt.SetActive(false);
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Raycast();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            interactTxt.SetActive(false);
            backTxt.SetActive(true);
        }

        if (puzzle1.win && puzzle2.win && puzzle3.win && puzzle4.win && !doorAux)
        {
            doorAux = true;
            interactTxt.SetActive(false);
            backTxt.SetActive(false);
            SoundManager.Instance.PlayDoor();
            win = true;
        }
    }

    #endregion

    #region Private Methods

    private void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 100, puzzleLayers))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Puzzle1"))
            {
                changeCamera.StartPuzzle1();
            }

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Puzzle2"))
            {
                changeCamera.StartPuzzle2();
            }

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Puzzle4"))
            {
                changeCamera.StartPuzzle4();
            }
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed);

        velocity.y += gravity;

        controller.Move(velocity * (Time.fixedDeltaTime * Time.fixedDeltaTime));
    }

    #endregion
}
