using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 3f;
    public LayerMask groundLayer;

    private float xRot;

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x, GetComponent<Rigidbody>().velocity.y * Time.deltaTime, z) * speed * Time.deltaTime);

        var rotateX = Input.GetAxis("Mouse X") * speed;

        transform.Rotate(Vector3.up, rotateX);

        VerticalLook();


        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
        }

    }

    private bool OnGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer))
        {
            return true;
        }

        return false;
    }

    private void VerticalLook()
    {
        var rotateY = -Input.GetAxis("Mouse Y") * speed;

        xRot += rotateY;

        Quaternion localRotation = Quaternion.Euler(xRot, 0, 0);
        Camera.main.transform.localRotation = localRotation;

        xRot = Mathf.Clamp(xRot, -80f, 80f);
    }
}
