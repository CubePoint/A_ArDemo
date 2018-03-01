using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBtn : MonoBehaviour {

	[SerializeField]
	private GameObject com_drag;
	private bool isdrag;

	void Awake() {
		isdrag = false;
	}



	public void btn_drag_start() {
		isdrag = true;
	}
	public void btn_drag() {
		Vector2 newpos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle ((RectTransform)transform,(Vector2)Input.mousePosition,null,out newpos);
		newpos.y = 0;
		com_drag.transform.localPosition = newpos;
	}
	public void btn_drag_end() {
		isdrag = false;
		com_drag.transform.localPosition = Vector3.zero;
	}

	public void btn_drop(bool isleft) {
		if (!isdrag)
			return;

		if (isleft) {
			PanelMg.Instant.togglePanel ("menupanel");
		}else {
			PanelMg.Instant.togglePanel ("checkpanel");
		}
	}

}
