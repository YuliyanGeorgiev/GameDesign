using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanAI : MonoBehaviour {

    public float speed;
    public Transform target;
    public float chaseRange;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float distanceToTarger = Vector3.Distance(transform.position, target.position);
        if (distanceToTarger < chaseRange)
        {
            anim.SetBool("sawPlayer", true);
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
	}
}
