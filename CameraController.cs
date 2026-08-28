using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public Vector3 camrotation = new Vector2(45f, 0f);

    private float movementX;
    private float movementY;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame, after all Update calls
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        Quaternion rot = Quaternion.Euler(camrotation);
        Vector3 lookDirection = rot * Vector3.forward;
        Vector3 lookPosition = (player.transform.position - lookDirection) * offset.magnitude;
        transform.SetPositionAndRotation(lookPosition, rot);


    }
    private void OnLook(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        


    }


}
