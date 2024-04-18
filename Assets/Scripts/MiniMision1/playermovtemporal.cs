using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovtemporal : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticalMove));
    }
}
