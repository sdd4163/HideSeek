using UnityEngine;
using System.Collections;

public class Seeker : Player {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//base.Update ();
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Tag Attempt");
			Tag ();
		}
	}

	void Tag () {
		//float distance = Vector3.Distance (playManager.Players [0].PlayerTransform.position, this.playerTransform.position);
		//if (distance < 2.0f) {
		//	Debug.Log ("Tagged");
		//} else {
		//	Debug.Log("Not Tagged");
		//}
	}
}
