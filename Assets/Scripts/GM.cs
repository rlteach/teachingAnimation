using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : Singleton {


	private	static	GM	sGM;

	void Awake () {
		if (CreateSingleton (ref sGM)) {
		}
	}
}
