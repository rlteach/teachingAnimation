using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo {
	public WheelCollider    LeftWheel;
    public WheelCollider    RightWheel;
    [HideInInspector]
    public Quaternion       mLeftWheelRotation;     //Used to store inital rotation to allow pre-rotation
    [HideInInspector]
    public Quaternion       mRightWheelRotation;
    public bool Motor;
	public bool Steering;
}

public class SimpleCarController : MonoBehaviour {
	public List<AxleInfo> axleInfos; 
	public float maxMotorTorque;
	public float maxSteeringAngle;

	void	Start() {
		Rigidbody	tRB = GetComponent<Rigidbody> ();
		tRB.centerOfMass += Vector3.down / 2f;  //Move Center of mass down for stability
        CacheInitialRotation();

    }

    void  CacheInitialRotation() {
        foreach (var tAxle in axleInfos) {
            tAxle.mLeftWheelRotation = GetWheelRotation(tAxle.LeftWheel);
            tAxle.mRightWheelRotation = GetWheelRotation(tAxle.RightWheel);
        }
    }

    Quaternion  GetWheelRotation(WheelCollider vCollider) {
        Transform tVisualWheel = vCollider.transform.GetChild(0);     //Get Wheel Mesh
        return tVisualWheel.transform.localRotation;
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider vCollider,Quaternion vInitalRotation)
	{
		if (vCollider.transform.childCount == 0) {
			return;
		}

		Transform tVisualWheel = vCollider.transform.GetChild(0);     //Get Wheel Mesh

		Vector3 tPosition;
		Quaternion tRotation;
		vCollider.GetWorldPose(out tPosition, out tRotation);

		tVisualWheel.transform.position = tPosition;
		tVisualWheel.transform.rotation = tRotation * vInitalRotation;
	}

	public void FixedUpdate()
	{
        float tThrottle = InputController.GetInput(InputController.Directions.Thrust);
        float tBrake = InputController.GetInput(InputController.Directions.Brake);
        float tMotor = maxMotorTorque * (tThrottle-(2f*tBrake));
		float tSteering = maxSteeringAngle * InputController.GetInput(InputController.Directions.MoveX);
        Debug.Log(tMotor);
		foreach (AxleInfo tAxleInfo in axleInfos) {
			if (tAxleInfo.Steering) {
				tAxleInfo.LeftWheel.steerAngle = tSteering;
				tAxleInfo.RightWheel.steerAngle = tSteering;
			}
			if (tAxleInfo.Motor) {
				tAxleInfo.LeftWheel.motorTorque = tMotor;
				tAxleInfo.RightWheel.motorTorque = tMotor;
			}
			ApplyLocalPositionToVisuals(tAxleInfo.LeftWheel,tAxleInfo.mLeftWheelRotation);
			ApplyLocalPositionToVisuals(tAxleInfo.RightWheel, tAxleInfo.mRightWheelRotation);
		}
	}
}