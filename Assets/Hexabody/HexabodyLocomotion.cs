using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexabodyLocomotion : MonoBehaviour
{
    public ConfigurableJoint Head;
    public ConfigurableJoint LocoBall;
    public Rigidbody LocoBallRigid;
    public float MonoBallTorque;
    public Vector3 Height;
    public float Down;
    public float Up;
    public float Horizontal;
    public float Vectical;
    public Quaternion headYaw;
    public Vector3 moveDirection;
    public Vector3 monoballTorque;
    public Camera Cam;
    public float MoveSpeed;
    public float BrakeDrag;
    public float Drag;
    public bool jumping;
    public GroundChecker GroundChecker;
    public float JumpFloat;
    public void Awake()
    {
        Head.targetPosition = Vector3.zero;
        Head.targetPosition = Height;

    }

    public void Update()
    {
        GroundChecker.Jump = jumping;
        Horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        Vectical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        headYaw = Quaternion.Euler(0, Cam.transform.eulerAngles.y, 0);
        moveDirection = headYaw * new Vector3(Horizontal, 0, Vectical);
        monoballTorque = new Vector3(moveDirection.z, 0, -moveDirection.x);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DownJump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UpJump();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(MoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(MoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(MoveSpeed);
        }
        
            if (moveDirection == Vector3.zero)
            {
                LocoBallRigid.angularDrag = BrakeDrag;
            } 
        
      
           if (moveDirection != Vector3.zero)
            {
                LocoBallRigid.angularDrag = Drag;    
            }
        


    }

    public void DownJump()
    {
        Head.targetPosition = Vector3.zero;
        Head.targetPosition = new Vector3(0, Down, 0);
    }
    public void UpJump()
    {
        Head.targetPosition = Vector3.zero;
        Head.targetPosition = new Vector3(0, Up, 0);
        LocoBall.transform.gameObject.GetComponent<Rigidbody>().AddForce(0, JumpFloat, 0);
    }

    public void Move(float Force)
    {
        LocoBallRigid.AddTorque(monoballTorque.normalized * Force, ForceMode.Force);
    }
}
