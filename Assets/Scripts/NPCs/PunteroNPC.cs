using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunteroNPC : MonoBehaviour
{

    public GameObject puntero;
    public float angleOfRotation;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        puntero.transform.Rotate(angleOfRotation * Vector3.up, Space.World);
    }
}
