using UnityEngine;
using System.Collections;
using XboxCtrlrInput;
using System.Diagnostics;
using System;

public class MoveCursor : MonoBehaviour {

	// Use this for initialization
	int option = 0;
	public GameObject arbeauObj, peakObj;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xAxis = Input.GetAxis("Horizontal");

		if (xAxis < 0) {
			transform.position = new Vector2(arbeauObj.transform.position.x, transform.position.y);
			option = 0;
		}

		if (xAxis > 0) {
			transform.position = new Vector2(peakObj.transform.position.x, transform.position.y);
			option = 1;
		}

		if (XCI.GetButtonDown(XboxButton.A)) {
			LaunchGame();
		}
	}

	void LaunchGame() {
		string gamePath = "Arbeau_BnP\\Arbeau.exe";
		if (option == 0) {
			//launch Arbeau
			gamePath = "Arbeau_BnP\\Arbeau.exe";

		}

		else if (option == 1) {
			//launch Peak
			gamePath = "Peak_BnP\\Peak.exe";
		}

		try {
			Process myProcess = new Process();
	        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
	        myProcess.StartInfo.CreateNoWindow = false;
	        // myProcess.StartInfo.UseShellExecute = false;
	        myProcess.StartInfo.FileName = "C:\\Users\\Dylan\\Desktop\\BnP\\" + gamePath;
	        myProcess.Start();
	    }
	    catch (Exception e) {
            Console.WriteLine(e.Message);
        }

        Application.Quit();
	}
}
