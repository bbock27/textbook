using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;
    private Vector2 movementValue;
    private float lookValue;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value){
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value){
        lookValue = value.Get<Vector2>().x * rotateSpeed;
        print(lookValue);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.W)) { transform.Translate(0,0,speed*Time.deltaTime); }
        // if(Input.GetKey(KeyCode.A)) { transform.Translate(-speed*Time.deltaTime,0,0); }
        // if(Input.GetKey(KeyCode.S)) { transform.Translate(0,0,-speed*Time.deltaTime); }
        // if(Input.GetKey(KeyCode.D)) { transform.Translate(speed*Time.deltaTime,0,0); }

        // float mouseX = Input.GetAxis("Mouse X");
        // transform.Rotate(0,mouseX * rotateSpeed*Time.deltaTime,0);

        transform.Translate(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        transform.Rotate(0,lookValue * Time.deltaTime, 0);
    }

    
}
