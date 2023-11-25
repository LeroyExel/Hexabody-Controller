using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool Jump;
    public void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),  out hit, 1f))
        {
            Jump = false;
        }else
        {
            Jump = true;
        }
    }
}
