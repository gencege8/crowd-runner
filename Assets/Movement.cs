using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 5f;
    public float dragSensitivity = 3f;
    Vector3 combinedVector;
    Vector3 dragVector = new Vector3(0,0,0);
    Vector3 forwardVector = Vector3.forward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime * moveSpeed);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime * moveSpeed);

        }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Moved)
            {
                dragVector=new Vector3(touch.deltaPosition.x * dragSensitivity, 0, 0);
            }
            if(touch.phase == TouchPhase.Stationary)
            {
                dragVector = new Vector3(0, 0, 0);
            }
        }
        else
        {
            dragVector = new Vector3(0,0,0);
        }
        combinedVector = (forwardVector*moveSpeed) + dragVector;
        rb.MovePosition(transform.position + combinedVector * Time.fixedDeltaTime);

    }
}
    
