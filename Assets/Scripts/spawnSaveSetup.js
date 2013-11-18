var startPoint : Transform;
//var soundDie : AudioClip;
//
//private var soundRate : float = 0.0;
//private var soundDelay : float = 0.0;
 var curSavePos : Vector3;
private var loseLife : boolean = false;


//
//function PlaySound(soundName,soundDelay)
//{
//
//	if(!audio.isPlaying && Time.time > soundRate)
//	{
//		soundRate=Time.time + soundDelay;
//		audio.clip=soundName;
//		audio.Play();
//		yield WaitForSeconds (audio.clip.length);
//	}
//
//}

//

function OnTriggerEnter (other : Collider)
{
	Debug.Log("trigger activado");
	

	Debug.Log("cambia pos");
		curSavePos = startPoint.position;

	
	if(other.tag == "killbox")
	{
//		PlaySound(soundDie,0);
//		loseLife=true;
		yield WaitForSeconds(1);
		renderer.enabled=false;
		renderer.enabled=true;
		transform.position=curSavePos;
	}
}

//

//function Start()
//{
//	if(startPoint !=null)
//	{
//		transform.position = startPoint.position;
//	}
//}

