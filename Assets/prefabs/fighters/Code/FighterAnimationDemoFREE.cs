using UnityEngine;
using System.Collections;

public class FighterAnimationDemoFREE : MonoBehaviour {
	
	public Animator animator;

	private Transform defaultCamTransform;
	private Vector3 resetPos;
	private Quaternion resetRot;
	private GameObject cam;
	private GameObject fighter;

	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera");
		defaultCamTransform = cam.transform;
		resetPos = defaultCamTransform.position;
		resetRot = defaultCamTransform.rotation;
		fighter = GameObject.FindWithTag("Player");
		fighter.transform.position = new Vector3(0,0,0);
	}

	void OnGUI () 
	{
		// if (GUI.RepeatButton (new Rect (815, 535, 100, 30), "Reset Scene")) 
		// {
		// 	defaultCamTransform.position = resetPos;
		// 	defaultCamTransform.rotation = resetRot;
		// 	fighter.transform.position = new Vector3(0,0,0);
		// 	animator.Play("Idle");
		// }

		if (Input.GetKey("w")) 
		{
			animator.SetBool("Walk Forward", true);
		}
		else
		{
			animator.SetBool("Walk Forward", false);
		}

		if (Input.GetKey("s")) 
		{
			animator.SetBool("Walk Backward", true);
		}
		else
		{
			animator.SetBool("Walk Backward", false);
		}

		if (Input.GetKey("p")) 
		{
			animator.SetTrigger("PunchTrigger");
		}
	}
}