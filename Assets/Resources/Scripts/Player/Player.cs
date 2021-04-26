using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public GameObject mainCamera;
    private Vector3 velocity;
    public float gravity = -9.81f;
    private ChangeCamera changeCamera;

    private void Start()
    {
        changeCamera = ChangeCamera.Instance;
    }

    void FixedUpdate()
    {
        if (mainCamera.activeInHierarchy)
        {
            Move();
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




    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Puzzle1"))
            {
                changeCamera.StartPuzzle1();
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Puzzle2"))
            {
                changeCamera.StartPuzzle2();
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Puzzle3"))
            {
                changeCamera.StartPuzzle3();
            }
        }
    }

}
