using UnityEngine;
using System.Collections;

public class ChopperController : MonoBehaviour {


	Animator	mANI;
	Rigidbody	mRB;

	// Grab references to stuff we will need
	void Start () {
		mANI = GetComponent<Animator> ();
		mRB = GetComponent<Rigidbody> ();
		//mRB.centerOfMass=Vector3.down * 0.5f;		//Makes it more stable
	}


	void FixedUpdate () {
		float	tThrust = InputController.GetInput (InputController.Directions.Thrust);
		float	tRoll = InputController.GetInput (InputController.Directions.MoveX);
		float	tPitch = InputController.GetInput (InputController.Directions.MoveY);
        mANI.SetBool("EngineOn", (tThrust > 0f));
        Vector3	tForce = Vector3.zero;
        tForce.y = -Physics.gravity.y * mANI.GetFloat("EngineSpeed") * tThrust;
        mANI.SetInteger("Pitch", Mathf.RoundToInt(tPitch));
        mANI.SetInteger("Roll", Mathf.RoundToInt(tRoll ));
        tForce.z = tPitch*3f;
		tForce.x = tRoll*3f;
		Debug.Log (tForce);
		mRB.AddForce (tForce,ForceMode.Force);		//Engine 1.5x G and depends on Rotor speed
	}

	void	LateUpdate () {     //Stop it goign too high
        Vector3 tPosition = transform.position;
        Vector3 tVelocity = mRB.velocity;
        if (tPosition.y>10f && tVelocity.y>0f) {
            tVelocity.y = 0;
            mRB.velocity = tVelocity;
        }
	}
}
