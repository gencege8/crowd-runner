using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    private Transform cam;
    private void Awake()
    {
        cam = GetComponent<Transform>();
    }
    void Start()
    {
        offset = cam.position-target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = target.position + offset;
        newPos.x = transform.position.x;
        transform.position = newPos;
    }
}
