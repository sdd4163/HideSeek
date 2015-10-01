using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour {

	private MyNetworkManager netManager;
	private bool isHider = false;

	// Use this for initialization
	void Start () {
		netManager = GameObject.Find ("NetManager").GetComponent<MyNetworkManager>();
		if (netManager.isHost) {
			isHider = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !isHider) {
			print ("clicked");
		}
	}
}
