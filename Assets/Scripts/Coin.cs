using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 30*Time.deltaTime, 0,Space.World);
	
	}
	
	public void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
			GameObject.Find("HUD").GetComponent<HUDmanager>().addScore(10);
		Destroy(transform.parent.gameObject);
	}
}
