using UnityEngine;
using System.Collections;

public enum position {hor_normal, hor_inversed, ver_right, ver_left}
public class Player : MonoBehaviour {
	
	public float speed;
    public float jumpSpeed;
    private Vector3 v3_moveDirection = Vector3.zero;
    private CharacterController controller;
	private float disToGround;
	public float maxV;
	public position pos;
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
		if(pos==position.ver_left || pos==position.ver_right)
		{
			if(Input.GetKey(KeyCode.UpArrow))
				transform.Translate(transform.up * speed*Time.deltaTime);
			else if(Input.GetKey(KeyCode.DownArrow))
				transform.Translate(transform.up * -speed*Time.deltaTime);
		}
		else
		{
			if(Input.GetKey(KeyCode.RightArrow))
				transform.Translate(transform.right * speed*Time.deltaTime);
			else if(Input.GetKey(KeyCode.LeftArrow))
				transform.Translate(transform.right * -speed*Time.deltaTime);
		}
		
		if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
		{
			switch(pos)
			{
			case position.hor_normal:
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, rigidbody.velocity.z);
				break;
			case position.hor_inversed:
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, -jumpSpeed, rigidbody.velocity.z);
				break;
			case position.ver_right:
				rigidbody.velocity = new Vector3(-jumpSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
				break;
			case position.ver_left:
				rigidbody.velocity = new Vector3(jumpSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
				break;
			}
		}
		
		//Checks for max velocity
		if(rigidbody.velocity.sqrMagnitude > (maxV*maxV))
		{
			rigidbody.velocity = rigidbody.velocity.normalized*maxV;
		}
    }
	
	
	public bool IsGrounded () 
	{
		switch(pos)
		{
		case position.hor_normal:
			return Physics.Raycast(transform.position, -Vector3.up, disToGround + 0.1f);
			break;
		case position.hor_inversed:
			return Physics.Raycast(transform.position, Vector3.up, disToGround + 0.1f);
			break;
		case position.ver_right:
			return Physics.Raycast(transform.position, Vector3.right, disToGround + 0.1f);
			break;
		case position.ver_left:
			return Physics.Raycast(transform.position, -Vector3.right, disToGround + 0.1f);
			break;
		}
		
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
	
	public IEnumerator changeGravity_Side(bool r)
	{
		if(r)
		{
			//reset
			Physics.gravity = new Vector3(9.8f,0f,0f);
		}
		else{
			this.gameObject.renderer.material.SetColor("_Color",Color.white);
			yield return new WaitForSeconds(0.4f);
			Physics.gravity *= -1;
	     	Gravitronned = true;
			
		}
	}

}
