using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchOne : MonoBehaviour {
	//史丹利模式
	private static CatchOne _Instant;
	public static CatchOne Instant {
		get { 
			if (_Instant == null)
				_Instant = FindObjectOfType<CatchOne> ();
			return _Instant;
		}
	}
	[SerializeField]
	private Image target;
	[SerializeField]
	private int ridx;

	public void show() {
		CanvasGroupUtility.show (GetComponent<CanvasGroup>());
		ridx = Random.Range(0,12);
		target.sprite = CardBoxMain.Instant.get_sprite (ridx);
	}
	public void hide() {
		CanvasGroupUtility.hide (GetComponent<CanvasGroup>());
	}

	public void btn_catch() {
		hide ();
		PanelMg.Instant.togglePanel ("bagpanel");
		CardBoxMain.Instant.addo_childNum(ridx);
	}
}