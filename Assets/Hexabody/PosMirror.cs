using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosMirror : MonoBehaviour
{
    public GameObject Head;

    public void FixedUpdate()
    {
        this.transform.position = Head.transform.position;
    }
}
