using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public GameObject mainCamera;
    private Vector3 velocity;
    public float gravity = -9.81f;
    private ChangeCamera changeCamera;
    public LayerMask puzzleLayers;
    private void Start()
    {
        changeCamera = ChangeCamera.Instance;
    }

    void FixedUpdate()
    {
        if (mainCamera.activeInHierarchy)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Raycast();
            }
        }




    }

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

}
