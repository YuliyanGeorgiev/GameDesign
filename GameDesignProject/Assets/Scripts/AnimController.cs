using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set animation for pooping
        bool isPoopingPressed = Input.GetKeyDown("r");
        anim.SetBool("isPooping", isPoopingPressed);


        //Set walking animation
        bool isWalkingPressed = Input.GetKey("w");
        anim.SetBool("isWalking", isWalkingPressed);

        //Set jumping animation
        bool isJumpingPressed = Input.GetKeyDown("space");
        anim.SetBool("isJumping", isJumpingPressed);

        //Set eating animation
        bool isEatingPressed = Input.GetKeyDown("e");
        anim.SetBool("isEating", isEatingPressed);

    }
}
