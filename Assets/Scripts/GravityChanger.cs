using UnityEngine;
using System.Collections;

public enum gravSide {horizontal, vertical, HV_R1, HV_R2, HV_Ri, HV_L1, HV_L2, HV_Li}
public enum colorChange{white, black}

public class GravityChanger : MonoBehaviour {
	
	public  gravSide dir;
	public bool changeColor;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		
		if(col.gameObject.tag == "Player")
			StartCoroutine(switchGravity(col.gameObject, dir, (dir==gravSide.HV_L2 || dir==gravSide.HV_R2)?true:false));
		
	}
	
	IEnumerator switchGravity(GameObject player, gravSide side, bool type)
	{
		Player playerScript = player.GetComponent<Player>();
		switch(side)
		{
		case gravSide.horizontal:
			yield return new WaitForSeconds(0.3f);
			if(playerScript.pos == position.hor_normal)
			{
				Physics.gravity = new Vector3(0,9.8f,0);
				if(changeColor)
					playerScript.changeState(position.hor_inversed,true);
			}
			else if(playerScript.pos == position.hor_inversed)
			{
				Physics.gravity = new Vector3(0,-9.8f,0);
				playerScript.changeState(position.hor_normal,changeColor);
			}
			break;
		case gravSide.vertical:
			yield return new WaitForSeconds(0.3f);
			if(playerScript.pos == position.ver_right)
			{
				Physics.gravity = new Vector3(-9.8f,0,0);
				playerScript.changeState(position.ver_left,changeColor);
			}
			else if(playerScript.pos == position.ver_left)
			{
				Physics.gravity = new Vector3(9.8f,0,0);
				playerScript.changeState(position.ver_right,changeColor);
			}
			break;
		case gravSide.HV_Li:
			if(playerScript.pos == position.hor_inversed)
			{
				Physics.gravity = new Vector3(-9.8f,0,0);
				player.rigidbody.AddForce(Vector3.right*60, ForceMode.VelocityChange);
				yield return new WaitForSeconds(0.2f);
				player.rigidbody.AddForce(Vector3.up*30, ForceMode.VelocityChange);
				playerScript.changeState(position.ver_left,changeColor);			
			}
			else if(playerScript.pos == position.ver_left)
			{
				Physics.gravity = new Vector3(0,9.8f,0);
				player.rigidbody.AddForce(Vector3.right*-10, ForceMode.VelocityChange);
				player.rigidbody.AddForce(Vector3.up*-5, ForceMode.VelocityChange);
				playerScript.changeState(position.hor_inversed,changeColor);
			}
			break;
		case gravSide.HV_L1:
			//from normal to left
			if(playerScript.pos == position.ver_left)
			{
				Physics.gravity = new Vector3(0,-9.8f,0);
				player.rigidbody.AddForce(Vector3.up*60, ForceMode.VelocityChange);
				yield return new WaitForSeconds(0.2f);
				player.rigidbody.AddForce(Vector3.right*-30, ForceMode.VelocityChange);
				playerScript.changeState(position.hor_normal,changeColor);
			}
			else if(playerScript.pos == position.hor_normal)
			{
				Physics.gravity = new Vector3(-9.8f,0,0);
				player.rigidbody.AddForce(Vector3.right*10, ForceMode.VelocityChange);
				player.rigidbody.AddForce(Vector3.up*-10, ForceMode.VelocityChange);
				playerScript.changeState(position.ver_left, changeColor);
			}
			break;
		case gravSide.HV_L2:
			//from normal to left
			if(playerScript.pos == position.ver_left)
			{
				Physics.gravity = new Vector3(0,-9.8f,0);
				player.rigidbody.AddForce(Vector3.right*30, ForceMode.VelocityChange);
				playerScript.changeState(position.hor_normal,changeColor);
			}
			else if(playerScript.pos == position.hor_normal)
			{
				Physics.gravity = new Vector3(-9.8f,0,0);
				playerScript.changeState(position.ver_left, changeColor);
			}
			break;
		}
	}
	
	IEnumerator switchHor_Gravity(GameObject player)
	{
		float posPlayer = player.transform.position.y;
		float pos = this.transform.position.y;
		yield return new WaitForSeconds(0.3f);
		if(posPlayer>pos)
		{
			Physics.gravity = new Vector3(0f,9.8f,0f);//Horizontal change to inversed
			player.renderer.material.SetColor("_Color",Color.white);
			player.GetComponent<Player>().pos = position.hor_inversed;
		}
		else
		{
			Physics.gravity = new Vector3(0f,-9.8f,0f);//Horizontal change to normal
			player.renderer.material.SetColor("_Color",Color.black);
			player.GetComponent<Player>().pos = position.hor_normal;
		}
	}
	
	IEnumerator switchVer_Gravity(GameObject player)
	{
		float posPlayer = player.transform.position.x;
		float pos = this.transform.position.x;
		yield return new WaitForSeconds(0.3f);
		if(posPlayer<pos)
		{
			Physics.gravity = new Vector3(-9.8f,0f,0f);//Horizontal change to inversed
			player.renderer.material.SetColor("_Color",Color.white);
			player.GetComponent<Player>().pos = position.ver_left;
			if(player.rigidbody.velocity.y < 2f)
			{
				//push a little
				player.rigidbody.velocity = new Vector3(4f,player.rigidbody.velocity.y,0f);
			}
		}
		else
		{
			Physics.gravity = new Vector3(9.8f,0f,0f);//Horizontal change to inversed
			player.renderer.material.SetColor("_Color",Color.black);	
			player.GetComponent<Player>().pos = position.ver_right;
		}	
	}
	
	IEnumerator switchHV_BLACK_Gravity(GameObject player)
	{
		float posPlayerx = player.transform.position.x;
		float posx = this.transform.position.x;
		yield return new WaitForSeconds(0.3f);
		if(posPlayerx<posx)
		{
			player.rigidbody.AddForce(Vector3.right*50, ForceMode.VelocityChange);
			player.rigidbody.AddForce(Vector3.up*50, ForceMode.VelocityChange);
			//player.rigidbody.velocity = new Vector3(6f,4f,0);
			Physics.gravity = new Vector3(-9.8f,0f,0f);//To left vertical
			player.renderer.material.SetColor("_Color",Color.white);
			player.GetComponent<Player>().pos = position.ver_left;

		}
		else
		{
			player.rigidbody.AddForce(Vector3.right*-20, ForceMode.VelocityChange);
			player.rigidbody.AddForce(Vector3.up*-1, ForceMode.VelocityChange);
			Physics.gravity = new Vector3(0,9.8f,0f);//To horizontal inversed
			player.renderer.material.SetColor("_Color",Color.white);
			player.GetComponent<Player>().pos = position.hor_inversed;
		}
		
	}
	
	IEnumerator switchVHL_Gravity(GameObject player)
	{
		float posPlayer = player.transform.position.y;
		float pos = this.transform.position.y;
		yield return new WaitForSeconds(0.3f);
		if(posPlayer<pos)
		{
			Physics.gravity = new Vector3(9.8f,0f,0f);//horizonta to vertical right
			player.renderer.material.SetColor("_Color",Color.black);
			player.GetComponent<Player>().pos = position.ver_right;

		}
		else
		{
			player.rigidbody.velocity = new Vector3(-6f,-6f,0);
			Physics.gravity = new Vector3(0,9.8f,0f);//Vertical right to horizontal inversed
			
			player.renderer.material.SetColor("_Color",Color.white);
			player.GetComponent<Player>().pos = position.hor_inversed;
		}
		
	}
}
