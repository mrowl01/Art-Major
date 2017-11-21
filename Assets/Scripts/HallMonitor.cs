using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallMonitor : MonoBehaviour 
{

	void OnMouseDown()
	{
		print ("I was clicked"); 
		gameObject.GetComponent<DialogueTrigger> ().TriggerDialogue (); 
	}

}
