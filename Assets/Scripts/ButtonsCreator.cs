using UnityEngine;
using System.Collections;

public class ButtonsCreator : MonoBehaviour {

	public GUIStyle invisibleButton;
	public GUIStyle buttonQuit;
	public GUIStyle buttonHelp;
	public GUIStyle buttonHelpNext;
	public GUIStyle buttonHelpPrev;
	public GUIStyle buttonHelpDone;

	public Texture creatorButt;
	public Texture headerIcon;
	public Texture page1HelpTexture;
	public Texture page2HelpTexture;
	
	private bool page1Help = false;
	private bool page2Help = false;

	public float scaleIcon = 1f;
	public float scaleButton = 0.8f; 			// untuk button "?" & quit
	public float scaleWide = 0.00012f;
	public float scaleWideZ = 11960f;

	public float posX1button = 0.027f;
	public float posX2button = 0.124f;

	float sw = Screen.width;
	float sh = Screen.height;

	private float scaleX = 1960f;
	private float scaleY = 1106f;
	public  float buttonScale = 0.8f; 			// untuk button next, prev, done

	//parameter sementara
	public float scaleUkuran = 0.6f;
	private float width = Screen.width; 		// ukuran menu help
	private float length = Screen.height;
	public float posX = Screen.width / 2;  		// posisi menu help
	public float posY = Screen.height / 2;
	public float posXNextButtonHelp = 0.69f;
	public float posYNextButtonHelp = 0.64f;
	public float posXPrevButtonHelp = 0.24f;
	public float posYPrevButtonHelp = 0.67f;
	public float posXLinkButton = 0.46f;
	public float posYLinkButton = 0.68f;
	public float scaleXLink = 1;
	public float scaleYLink = 1;

	
	public float headerHeight = 7.4766f;

	void OnGUI() {
		float guiMarginX = sw * 1/20;   					// batas margin X dari kanan
		float guiW = sw * 0.1f * scaleButton; 				// button width
		float guiXQuit = sw - guiMarginX - guiW/1.5f;   	// X posisi button quit
		float guiXHelp = guiMarginX;
		
		float guiMarginY = sh * 1/20; 						// batas margin Y dari atas
		float guiH = sh * 0.16f * scaleButton;  			// button height
		float guiY = sh * 1/4;								// Y posisi butto


		GUI.DrawTexture(new Rect(0,0,sw,sw*0.0984375f), headerIcon);
		GUI.DrawTexture(new Rect (0, sh - (sh * (scaleIcon * 0.00012f * scaleY)), sw * (scaleIcon * 0.00012f * scaleX), 
		                          sh * (scaleIcon * 0.00012f * scaleY)), creatorButt);

		if (GUI.Button (new Rect (guiXQuit, guiMarginY/2.5f, guiW/1.5f, guiH/1.5f), "", buttonQuit))
		{
			Application.Quit ();
		}
		if (GUI.Button (new Rect (guiXHelp, guiMarginY/2.5f, guiW/1.5f, guiH/1.5f), "", buttonHelp))
		{
			if (page1Help == false && page2Help == false)
			{
				page1Help = true;
			} else 
			if (page2Help == true && page1Help == false)
			{
				page2Help = false;
			} else page1Help = false;
		}
		if (page1Help)
		{
			GUI.DrawTexture (new Rect (sw/2 - scaleUkuran*width/2, sh/2 - scaleUkuran*length/2, scaleUkuran*width, scaleUkuran*length), page1HelpTexture);
			if (GUI.Button(new Rect(sw * posXLinkButton, sh * posYLinkButton, guiW*0.5f*scaleXLink, guiH*0.5f*scaleYLink), "", invisibleButton))
			{
				Application.OpenURL("http://bit.ly/arturmarker");
			}
			if (GUI.Button(new Rect(sw * posXNextButtonHelp, sh* posYNextButtonHelp, guiW*0.5f, guiH*0.5f), "", buttonHelpNext))
			{
				page1Help = false;
				page2Help = true;
			}
		}
		if (page2Help)
		{
			GUI.DrawTexture (new Rect (sw/2 - scaleUkuran*width/2, sh/2 - scaleUkuran*length/2, scaleUkuran*width, scaleUkuran*length), page2HelpTexture);
			if (GUI.Button(new Rect(sw * posXPrevButtonHelp, sh * posYPrevButtonHelp, guiW*0.5f, guiH*0.5f), "", buttonHelpPrev))
			{
				page1Help = true;
				page2Help = false;
			}
			if (GUI.Button(new Rect(sw * posXNextButtonHelp, sh * posYNextButtonHelp, guiW, guiH), "", buttonHelpDone))
			{
				page1Help = false;
				page2Help = false;
			}
		}

//		if (GUI.Button (new Rect (0, Screen.height - (Screen.height * (scaleIcon*0.00012f * scaleY)), Screen.width * (scaleIcon*0.00012f * scaleX), Screen.height * (scaleIcon*0.00012f * scaleY)),"", creatorButton)){
//				Application.OpenURL("http://www.visitingjogja.com/");
//			}

	}
}
