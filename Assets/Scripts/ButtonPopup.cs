using UnityEngine;
using System.Collections;
using Vuforia;

public class ButtonPopup : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	
	private bool mShowGUIButton = false;
	
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			mShowGUIButton = true;
		}
		else
		{
			mShowGUIButton = false;
		}
	}
	public GameObject objek3d;
	public GameObject objekVideo;
	public GameObject objekInfo;
	
	public GUIStyle button3d;
	public GUIStyle buttonVideo;
	public GUIStyle buttonInfo;
	public float wScale = 0.1f;
	public float hScale = 0.16f;
	public float buttonScale = 0.8f;
	
	void Awake()
	{
		objekVideo.SetActive (true);
		objek3d.SetActive (false);
		objekInfo.SetActive (false);
	}
	
	void OnGUI() {
		if (mShowGUIButton) {
			int sw = Screen.width;
			int sh = Screen.height;
			int guiMarginX = sw * 1 / 20;   // 화면 가로 여백  //64
			float guiW = sw * wScale * buttonScale;  // 메뉴 너비  //160
			float guiX = sw - guiMarginX - guiW;  // 메뉴 가로 시작위치   //1280-64-160
			
			int guiMarginY = sh * 1/ 20;    // 화면 세로 여백   //64
			float guiH = sh * hScale * buttonScale; //  메뉴 높이   //160
			float guiY = sh * 1/ 4; 
			// draw the GUI button
			if (GUI.Button(new Rect( guiX, guiY, guiW, guiH), "",buttonVideo))
			{
				SetVideo();
			}
			guiY += guiH + guiMarginY;
			if (GUI.Button(new Rect( guiX, guiY, guiW, guiH), "",button3d))
			{
				Set3d();
			}
			guiY += guiH + guiMarginY;
			if (GUI.Button(new Rect( guiX, guiY, guiW, guiH), "",buttonInfo))
			{
				SetInfo();
			}
			//			if (GUI.Button(mButtonRect, "Hello")) {
			//				// do something on button click 
			//			}
		}
	}
	
	public void Set3d(){
		objek3d.SetActive (true);
		objekVideo.SetActive (false);
		objekInfo.SetActive (false);
	}
	
	public void SetVideo(){
		objekVideo.SetActive (true);
		objek3d.SetActive (false);
		objekInfo.SetActive (false);
	}
	public void SetInfo(){
		objekInfo.SetActive (true);
		objekVideo.SetActive (false);
		objek3d.SetActive (false);
	}
}