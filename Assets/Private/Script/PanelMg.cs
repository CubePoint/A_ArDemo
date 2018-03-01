using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PanelMg : MonoBehaviour {
	//史丹利模式
	private static PanelMg _Instant;
	public static PanelMg Instant {
		get { 
			if (_Instant == null)
				_Instant = FindObjectOfType<PanelMg> ();
			return _Instant;
		}
	}

	[SerializeField]
	private GameObject mainCamera;
	[SerializeField]
	private GameObject arCamera;
	[SerializeField]
	private GameObject arEnv;
	private Dictionary<string, GameObject> panels;
	private string currentpanel;

	void Awake () {
		currentpanel = "menupanel";
		panels = new Dictionary<string, GameObject> () {
			{"menupanel",transform.Find("menupanel").gameObject},
			{"bagpanel",transform.Find("bagpanel").gameObject},
			{"checkpanel",transform.Find("checkpanel").gameObject}
		};
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)||Input.GetKeyDown (KeyCode.Backspace)) {
			togglePanel("menupanel");
		}
	}

	public void togglePanel(string s) {
		if (currentpanel == s)
			return;
		CanvasGroupUtility.hide (panels [currentpanel].GetComponent<CanvasGroup>());
		CanvasGroupUtility.show (panels [s].GetComponent<CanvasGroup>());
		currentpanel = s;
		switch (s) {
		case "menupanel":
			mainCamera.SetActive (true);
			arCamera.SetActive (false);
				break;
			case "bagpanel":
			mainCamera.SetActive (true);
			arCamera.SetActive (false);
				break;
			case "checkpanel":
			mainCamera.SetActive (false);
			arCamera.SetActive (true);
				break;
		}
		arEnv.SetActive (arCamera.activeSelf);
	}



}
