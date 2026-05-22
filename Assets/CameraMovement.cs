using UnityEngine;
using static GameManager;

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
        if (GameManager.instance.currentState != GameState.Playing) return;
        Vector3 newPos = target.position + offset;
        newPos.x = transform.position.x;
        transform.position = newPos;
    }
}
