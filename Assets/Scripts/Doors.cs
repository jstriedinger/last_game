using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {
	public GameObject door;
	public string dir;
	public float openDuration;
	private Vector3 targetPosition;
	private bool moveOpen;
	private bool moveClose;
	private bool isOpen;
	private float initialX;
	private float initialY;
	private Color def;
	
	
	// Use this for initialization
	void Start () {
		
		isOpen=false;
		initialX = door.transform.localPosition.x;
		initialY = door.transform.localPosition.y;
		def = gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(moveOpen)
			door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, targetPosition, Time.deltaTime *8);
		else if(moveClose)
			door.transform.localPosition = Vector3.Lerp(door.transform.localPosition,new Vector3(initialX,initialY,0), Time.deltaTime*8);
	}
	
	public void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag=="Player" && !isOpen)
		{
			//Opens the door
			openDoor();
		}
	}
	
    public void openDoor()
	{
		float finalX = 0;
		float finalY = 0;
		string finalDir = "";
		if(dir=="right")
		{
			finalX = door.transform.localPosition.x + 3f;
			finalDir = "H";
		}
		else if(dir=="left")
		{
			finalX = door.transform.localPosition.x - 3f;
			finalDir = "H";
		}
		else if(dir=="up")
		{
			finalY = door.transform.localPosition.y + 3f;
			finalDir = "V";
		}
		else if(dir=="down")
		{
			finalY = door.transform.localPosition.y - 3f;
			finalDir = "V";
		}
		isOpen = true;
		gameObject.renderer.material.SetColor("_Color",new Color(0.039f,0.039f,0.039f,1f));
		StartCoroutine(moveDoor(finalDir,finalX,finalY));		
	}
	
	IEnumerator moveDoor(string dir, float x, float y)
	{
		if(dir=="H")
		{
			targetPosition = new Vector3(x,door.transform.localPosition.y,0);
		}
		else if(dir=="V")
		{
			targetPosition = new Vector3(door.transform.localPosition.x,y,0);
		}
		moveClose=false;
		moveOpen = true;
		
		yield return new WaitForSeconds(openDuration);
		moveOpen = false;
		moveClose = true; 
		isOpen = false;
		gameObject.renderer.material.SetColor("_Color",def);
		
	}
}
