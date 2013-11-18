var timeToPort : float = 2.0;
var tubePortalTo : Transform;


private var moveDown : boolean = false;
private var moveUp : boolean = false;

//

function OnTriggerStay(other:Collider)
{
	if(other.tag == "Player")
	{
		if(Input.GetAxis("Vertical")<0)
		{
			

			moveDown = true;
			if(moveDown)
			{
			
				other.transform.Translate(0,-5 * Time.deltaTime,0);
				
				yield WaitForSeconds (.2);
				other.renderer.enabled=false;
				yield WaitForSeconds (timeToPort);
				other.transform.position = tubePortalTo.transform.position;
				moveDown = false;
				moveUp = true;
			}
			
			if(moveUp)
			{
				yield WaitForSeconds (1);
				
			
				other.renderer.enabled=true;
				other.transform.Translate(0,4*Time.deltaTime,0);
				yield WaitForSeconds (.3);
				
				moveUp=false;
			}
			
		}
		
	}
}

