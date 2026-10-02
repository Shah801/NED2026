using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //float decimal 1.1f
    //double decimal without f signature 1.1
    //int 1,2,3,4
    //string alphanumeric and special characters
    // Time.DeltaTime
    // var flexible 
    // Bool True or False

    public int TargetFPS = 100;
    public int Speed = 20;
    public int RotationSpeed = 5;

    public int JumpForce = 10;

    public Rigidbody rigidBody;

    private bool isJumping = false;


    void Update()
    {
        Application.targetFrameRate = TargetFPS;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isJumping = Input.GetKeyDown(KeyCode.Space);

        if(isJumping == true)
        {
            rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);            
        }

        // print("Horizontal Value: " + horizontal+" |Vertical Value: "+ vertical);
        Vector3 moveDirection = (horizontal * Vector3.right) 
        + (vertical * Vector3.forward);
        transform.position += moveDirection * Time.deltaTime * Speed;
        // Lerp SLerp
       if(moveDirection.magnitude > 0.1)
        {
        transform.rotation = Quaternion.Slerp(transform.rotation,
         Quaternion.LookRotation(moveDirection, Vector3.up),
         RotationSpeed * Time.deltaTime);
        }

    }
}
