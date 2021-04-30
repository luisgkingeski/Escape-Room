using UnityEngine;

public class Perspective : MonoBehaviour
{
    [Header("Components")]
    public Transform target;

    [Header("Parameters")]
    public LayerMask targetMask;
    public LayerMask ignoreTargetMask;
    public float offsetFactor;

    float originalDistance;
    float originalScale;
    Vector3 targetScale;

    void Update()
    {
        HandleInput();
        ResizeTarget();
    }

    void HandleInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (target == null)
            {

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetMask))
                {

                    target = hit.transform;

                    target.GetComponent<Rigidbody>().isKinematic = true;


                    originalDistance = Vector3.Distance(transform.position, target.position);

                    originalScale = target.localScale.x;

                    targetScale = target.localScale;
                }
            }
            else
            {
                target.GetComponent<Rigidbody>().isKinematic = false;
                target = null;
            }
        }
        if (Input.GetMouseButtonUp(0) && target != null)
        {
            target.GetComponent<Rigidbody>().isKinematic = false;
            target = null;
        }
    }

    void ResizeTarget()
    {
        if (target == null)
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ignoreTargetMask))
        {

            target.position = hit.point - transform.forward * offsetFactor * targetScale.x;

            float currentDistance = Vector3.Distance(transform.position, target.position);

            float s = currentDistance / originalDistance;

            targetScale.x = targetScale.y = targetScale.z = s;

            target.localScale = targetScale * originalScale;

            if (target.localScale.x >= 9.5f && target.localScale.y >= 9.5f && target.localScale.z >= 9.5f)
            {
                target.localScale = Vector3.one * 9.5f;
            }
            else

            if (target.localScale.x <= 0.04f && target.localScale.y <= 0.04f && target.localScale.z <= 0.04f)
            {
                target.localScale = Vector3.one * 0.04f;
            }
        }
    }
}
