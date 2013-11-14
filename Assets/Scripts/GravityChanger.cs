using UnityEngine;
using System.Collections;

public enum gravSide {horizontal, vertical, Ho_Ve_r, Ho_Ve_l}
public enum colorChange{white, black}

public class GravityChanger : MonoBehaviour {
	
	public  gravSide dir;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			
			switch(dir)
			{
			case gravSide.horizontal:
				StartCoroutine(switchHor_Gravity(col.gameObject));
				break;
			case gravSide.vertical:
				StartCoroutine(switchVer_Gravity(col.gameObject));
				break;
			case gravSide.Ho_Ve_r:
				StartCoroutine(switchHVR_Gravity(col.gameObject));
				break;
			}
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
		}
		else
		{
			Physics.gravity = new Vector3(9.8f,0f,0f);//Horizontal change to inversed
			player.renderer.material.SetColor("_Color",Color.black);	
			player.GetComponent<Player>().pos = position.ver_right;
		}	
	}
	
	IEnumerator switchHVR_Gravity(GameObject player)
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
