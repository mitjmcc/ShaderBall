using UnityEngine;

public class CameraPanAndRotate : MonoBehaviour
{
    public Transform focus;
    public float rotateSpeed = 150f;
    public float scrollSpeed = 100f;

    void Start()
    {
        if (focus == null)
        {
            GameObject f = new GameObject("Focus");
            f.transform.position = Vector3.zero;
            focus = f.transform;
        }
    }

    void Update()
    {
        // Left mouse click rotates around
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(focus.position, Vector3.up, Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime);
            transform.RotateAround(focus.position, -transform.right, Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime);
        }
        else if (!Mathf.Approximately(Input.GetAxisRaw("Mouse ScrollWheel"), 0f))
        {
            transform.Translate(transform.forward * Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime, Space.World);
        }
    }
}
