using UnityEngine;

public class Ball : MonoBehaviour
{
    #region MonoBehaviour Callbacks

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Puzzle3"))
        {
            Puzzle3.Instance.Win();
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Puzzle3"))
        {
            Puzzle3.Instance.Win();
        }
    }

    #endregion
}
