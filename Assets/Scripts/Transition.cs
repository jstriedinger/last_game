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
		/*
		if(other.gameObject.tag == "Player")
		{
			switch(direction)
			{
			case gravSide.right:
				StartCoroutine(other.gameObject.GetComponent<Player>().changeGravity_Side(true));
				break;
			case gravSide.left:
				StartCoroutine(other.gameObject.GetComponent<Player>().changeGravity_Side(false));
				break;
			case gravSide.normal:
				StartCoroutine(other.gameObject.GetComponent<Player>().changeGravity());
				break;
			}
		}*/
	}
	
	
}
