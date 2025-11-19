using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 10f; // speed of walking
    public float runSpeed = 20f; // speed of running
    public Transform cameraTransform; // reference to the camera transform
    public float mouseSens = 2f; // mouse sensitivity for controller

    private CharacterController controller;
    private UnityEngine.Vector3 movedirection;
    private UnityEngine.Vector3 playerVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        //lock the cursor to the center of the screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float horizontal = Input.GetAxis("Horizontal"); //AD Keys
        float vertical = Input.GetAxis("Vertical"); //WS Keys

        movedirection = transform.right * horizontal + transform.forward * vertical;
        controller.Move(movedirection * moveSpeed * Time.deltaTime);

        //isMoving = ((inputs.x != 0) ? true : false) || ((inputs.y != 0) ? true : false);

        //Apply gravity to the player 
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Player camera control
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        Vector3 currentRotation = cameraTransform.rotation.eulerAngles;
        float desiredRotationX = currentRotation.x - mouseY;
        if (desiredRotationX > 100)
        {
            desiredRotationX -= 360;
        }
        desiredRotationX = Mathf.Clamp(desiredRotationX, -90f, 90f);
        cameraTransform.rotation = UnityEngine.Quaternion.Euler(desiredRotationX, currentRotation.y, currentRotation.z);
    }
}
