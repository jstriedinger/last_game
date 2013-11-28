using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour {
	
	private Vector3 startPoint;
	public GameObject player;
	// Use this for initialization
	void Start () {
		startPoint = player.transform.position;
	
	}
	public void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag=="Player")
		{
			//reset
			player.transform.position = startPoint;
			player.GetComponent<Player>().changeState(position.hor_normal,false);
			Physics.gravity = new Vector3(0,-9.8f,0);
			player.GetComponent<Player>().changeColor(true);
		}
	}
}
