using UnityEngine;
using System.Collections;

public class TankController : AnimationHelper {

	public	GameObject	ShellPrefab;

	public	float	CoolDown = 1f;

	private	float	mCoolDown=0f;

	// Use this for initialization
	protected	override	void Start () {
		base.Start ();		//Ensure Base method is called
		mAnimator.SetFloat ("Speed",1f);
	}
	
	// Update is called once per frame
	protected	void Update () {
		int	tDirection = Mathf.RoundToInt (InputController.GetInput (InputController.Directions.MoveY));
		mAnimator.SetInteger ("Direction",tDirection);
		Quaternion	tRotation=Quaternion.Euler(0,0,InputController.GetInput (InputController.Directions.MoveX)*360f*Time.deltaTime);
		transform.rotation *= tRotation;
		if (mCoolDown > 0f) {
			mCoolDown -= Time.deltaTime;
		}
		if (mCoolDown <= 0f) {
			if (InputController.GetInput (InputController.Directions.Fire) > 0f) {
				mCoolDown = CoolDown;
				GameObject tShellGO = Instantiate (ShellPrefab);
				tShellGO.transform.rotation = transform.rotation;
				tShellGO.transform.position = transform.position + transform.rotation * (Vector2.up * 0.5f);
			}
		}
	}
}
