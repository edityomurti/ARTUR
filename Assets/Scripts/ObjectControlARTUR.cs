using UnityEngine;
using System.Collections;

public class ObjectControlARTUR : MonoBehaviour {

	public GameObject objek3d;
	public GameObject objekVideo;
	public GameObject objekInfo;

	public GUIStyle button3d;
	public GUIStyle buttonVideo;
	public GUIStyle buttonInfo;
	public GUIStyle buttonQuit;

	public float luasButton = 0.1f;
	public float x1Button = 0.89f;
	public float y1Button = 0.01f;
	public float y2Button = 0.19f;
	public float y3Button = 0.37f;
	public float yQuit = 0f;

	void Start(){
		objekVideo.SetActive (true);
		objek3d.SetActive (false);
		objekInfo.SetActive (false);
	}
	
	// Update is called once per frame
	void OnGUI() {
				if (GUI.Button (new Rect (Screen.width * x1Button, Screen.height * y1Button, Screen.width * luasButton, Screen.width * luasButton), "", buttonVideo)) {
						objek3d.SetActive (false);
						objekVideo.SetActive (true);
						objekInfo.SetActive (false);
				}
				if (GUI.Button (new Rect (Screen.width * x1Button, Screen.height * y2Button, Screen.width * luasButton, Screen.width * luasButton), "", button3d)) {
						objek3d.SetActive (true);
						objekVideo.SetActive (false);
						objekInfo.SetActive (false);
				}
				if (GUI.Button (new Rect (Screen.width * x1Button, Screen.height * y3Button, Screen.width * luasButton, Screen.width * luasButton), "", buttonInfo)) {
						objek3d.SetActive (false);
						objekVideo.SetActive (false);
						objekInfo.SetActive (true);
				}
				if (GUI.Button (new Rect (Screen.width * x1Button, Screen.height * yQuit, Screen.width * luasButton, Screen.width * luasButton), "", buttonQuit)) {
						Application.Quit ();
				}
		}
}
