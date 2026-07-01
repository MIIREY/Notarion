using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow")]
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 3, -10);

    [Header("Dynamic Look Ahead")]
    public float lookAheadDistance = 2f;
    public float lookAheadSpeed = 3f;

    private Rigidbody2D targetRb;
    private Vector3 currentLookAhead;

    void Start()
    {
        if (target != null)
            targetRb = target.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Menghitung arah gerakan player
        Vector3 desiredLookAhead = Vector3.zero;

        if (targetRb != null)
        {
            desiredLookAhead.x = Mathf.Sign(targetRb.linearVelocity.x) *
                                 Mathf.Min(Mathf.Abs(targetRb.linearVelocity.x), 1f) *
                                 lookAheadDistance;
        }

        currentLookAhead = Vector3.Lerp(
            currentLookAhead,
            desiredLookAhead,
            lookAheadSpeed * Time.deltaTime
        );

        Vector3 desiredPosition = target.position + offset + currentLookAhead;

        // Paksa kamera tetap di belakang player
        desiredPosition.z = -10f;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}