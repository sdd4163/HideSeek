﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MyNetworkManager: NetworkManager
{
	
	public static NetworkClient myClient;
	
	[SerializeField]
	Button
		hostButton;
	[SerializeField]
	Button
		joinButton;
	[SerializeField]
	InputField
		usernameText;
	[SerializeField]
	InputField
		IPButton;
	[SerializeField]
	private string username;
	public string GetUsername(){return username;}

	public bool isHost;
	
	
	void Start ()
	{
		print ("MyNetworkManager : Start");
		
	}
	
	void SetUsername()
	{
		username = GameObject.Find ("txtUsername").transform.FindChild ("Text").GetComponent<Text> ().text;
		
	}
	//get input from text input fields
	void SetIPAddress ()
	{
		string ipAddress = GameObject.Find ("txtIP").transform.FindChild ("Text").GetComponent<Text> ().text;
		NetworkManager.singleton.networkAddress = "127.0.0.1";//ipAddress;
	}
	
	void SetPort ()
	{
		NetworkManager.singleton.networkPort = 10777;
	}
	
	// button event handlers
	public void StartupHost ()
	{
		print ("clicked button, starting host (we hope)");
		isHost = true;
		SetIPAddress ();
		SetPort ();
		SetUsername ();
		NetworkManager.singleton.StartHost ();
	}
	
	public void JoinGame ()
	{
		print ("clicked button, join game");
		isHost = false;
		SetIPAddress ();
		SetPort ();
		SetUsername ();
		NetworkManager.singleton.StartClient ();
	}
	
	public void Disconnect ()
	{
		NetworkManager.singleton.StopHost ();
	}
	
	//make sure correct buttons appear on different scenes 
	void OnLevelWasLoaded (int level)
	{
		print ("Level Loaded : " + level);
		if (level == 0) {
			SetupLoginButtons ();
		} else {
			SetupChatSceneButtons ();
		}
	}
	
	
	//Do this in code because when we leave a scene, all objects are destroyed. 
	//Then when we return, the objects are new, and we will have lost our references.
	void SetupLoginButtons ()
	{
		print ("MyNetworkManager : SetupMenuSceneButtons");
		
		GameObject.Find ("btnHostGame").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("btnHostGame").GetComponent<Button> ().onClick.AddListener (StartupHost);
		
		GameObject.Find ("btnJoinGame").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("btnJoinGame").GetComponent<Button> ().onClick.AddListener (JoinGame);
		
	}
	
	void SetupChatSceneButtons ()
	{
		GameObject.Find ("btnDisconnect").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("btnDisconnect").GetComponent<Button> ().onClick.AddListener (NetworkManager.singleton.StopHost);
		
		//chat = GameObject.Find ("ChatGO").GetComponent<Chat> ();
	}
}


