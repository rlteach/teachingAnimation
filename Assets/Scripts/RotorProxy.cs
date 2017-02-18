using UnityEngine;
using System.Collections;

public class RotorProxy : MonoBehaviour {

	public	float	RotorSpeed;

	Animator	mANI;

	// Use this for initialization
	void Start () {
		mANI = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		mANI.SetFloat ("RotorSpeed", RotorSpeed);
	}
}
