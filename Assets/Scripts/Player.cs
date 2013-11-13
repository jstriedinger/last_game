using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
    public float jumpSpeed;
    private Vector3 v3_moveDirection = Vector3.zero;
    private CharacterController controller;
	private float disToGround;
	public bool Gravitronned = false;
	
	void Start()
	{
		disToGround = collider.bounds.extents.y;
	}
 
    void Awake ()
    {
		   
	}
 
    void Update ()
    {
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Translate(transform.right * speed*Time.deltaTime);
		else if(Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(transform.right * -speed*Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    		rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, rigidbody.velocity.z);   
    }
	
	
	public bool IsGrounded () {
  		return Physics.Raycast(transform.position, -Vector3.up, disToGround + 0.1f);
	}
	
	
	public void changeGravity()
	{
		Debug.Log("gravity was: "+Gravitronned);
		if(Gravitronned)
			Physics.gravity *= 1;
		
		Physics.gravity *= -1;
     	Gravitronned = true;
	
		Debug.Log("gravity now is: "+Gravitronned);
	}

}
