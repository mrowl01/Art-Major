using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour 
{
	public Text nameText;
	public Text dialogueText;
	private Queue<string> sentences; 
	public Animator animator;

	// Use this for initialization
	void Start ()
	{
		sentences = new Queue<string> ();

	}
	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool ("isOpen", true);
		nameText.text = dialogue.name; 

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue (sentence);
			
		}
		DisplayNextSentence ();
	}
	public void DisplayNextSentence()
	{
		if (sentences.Count ==0) // reach end of que
		{
			EndDialogue ();
			return;
		}
		string nextSentence = sentences.Dequeue (); //if we have sentences left to say- get next setnence in que
		StopAllCoroutines();
		StartCoroutine(TypeSentence(nextSentence));
		//dialogueText.text= nextSentence;
	}
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) 
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool ("isOpen", false); 
	}
}
