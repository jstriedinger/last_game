using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {
	
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
			StartCoroutine(ChangeGravity(other.gameObject));
	}
	
	IEnumerator ChangeGravity(GameObject player)
	{
		yield return new WaitForSeconds(0.4f);
		player.GetComponent<Player>().changeGravity();
	}
}
