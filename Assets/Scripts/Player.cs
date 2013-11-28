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
	private Color current;
	
	private Color myWhite = new Color(0.925f,0.941f,0.945f,1f);
	private Color myBlack = new Color(0.05f,0.05f,0.05f,1f);
	
	void Start()
	{
		disToGround = collider.bounds.extents.y;
		current = myBlack;
		pos = position.hor_normal;
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
	
	public void changeState(position newPos, bool switchColor)	
	{
		pos = newPos;
		if(switchColor)
		{
			current = (current== myWhite?myBlack:myWhite);
			this.renderer.material.SetColor("_Color",current);
		}
	}

}
