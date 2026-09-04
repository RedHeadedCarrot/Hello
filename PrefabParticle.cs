
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    public Vector3 offset;

    public Vector2 camRotation = new Vector2(45f, 0f);
    public Vector2 input = new Vector2();

    public float rotationSpeed = 10f;

    // Start is called before the first frame update.
    void Start()
    {
        // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Orbit camera based on target
        Quaternion lookRotation = Quaternion.Euler(camRotation);
        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = player.transform.position - lookDirection * offset.magnitude;
        transform.SetPositionAndRotation(lookPosition, lookRotation);
        camRotation += rotationSpeed * Time.deltaTime * input;
        if(p==null)
        return
    }



    private void OnLook(InputValue inputValue)
    {
        Vector2 tInput = inputValue.Get<Vector2>();
        input.x = tInput.y;
        input.y = tInput.x;

    }
}
