using UnityEngine;
using System.Collections;

public class HUDmanager : MonoBehaviour {
	
	public GUIText scoreGUI;
	public int score = 0;
	
	public  void addScore(int x)
	{
		score += x;
		int numDigits = score.ToString().Length;
		if(numDigits==1)
			scoreGUI.text = "000"+score.ToString();
		else if(numDigits==2)
			scoreGUI.text = "00"+score.ToString();
		else if(numDigits==3)
			scoreGUI.text = "0"+score.ToString();
		else
			scoreGUI.text = score.ToString();
	}
}
