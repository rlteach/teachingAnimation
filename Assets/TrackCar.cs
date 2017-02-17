using UnityEngine;
using System.Collections;

public class TrackCar : MonoBehaviour {

	public	GameObject	Target;

	Vector3		mStartOffset;

	// Use this for initialization
	void Start () {
		mStartOffset = transform.position;
	}
	
	// LateUpdate is called after Update each frame
	void LateUpdate ()  {
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = Target.transform.position+mStartOffset;
	}
}