using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
    public float jumpSpeed;
    private Vector3 v3_moveDirection = Vector3.zero;
    private CharacterController controller;
	private float disToGround;
	public float maxV;
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
		if(Input.GetKey(KeyCode.RightArrow) && !cantMove(true))
			transform.Translate(transform.right * speed*Time.deltaTime);
		else if(Input.GetKey(KeyCode.LeftArrow) && !cantMove(false))
			transform.Translate(transform.right * -speed*Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			Debug.Log("isgrounded");
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, Gravitronned?jumpSpeed*-1:jumpSpeed, rigidbody.velocity.z);
		}
		
		//Checks for max velocity
		if(rigidbody.velocity.sqrMagnitude > (maxV*maxV))
		{
			rigidbody.velocity = rigidbody.velocity.normalized*maxV;
		}
    }
	
	
	public bool IsGrounded () 
	{
		
  		return Physics.Raycast(transform.position, Gravitronned?Vector3.up:-Vector3.up, disToGround + 0.1f);
	}
	
	public bool cantMove(bool r)
	{
		return Physics.Raycast(transform.position, r?Vector3.right:-Vector3.right, disToGround+0.1f);
	}
	

	
	
	public IEnumerator changeGravity()
	{
		if(Gravitronned)
		{
			this.gameObject.renderer.material.SetColor("_Color",Color.black);
			yield return new WaitForSeconds(0.4f);
			Physics.gravity *= -1;
			Gravitronned = false;
		}
		else{
			this.gameObject.renderer.material.SetColor("_Color",Color.white);
			yield return new WaitForSeconds(0.4f);
			Physics.gravity *= -1;
	     	Gravitronned = true;
			
		}
	}

}
