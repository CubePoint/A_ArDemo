using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupUtility {

	public static void show(CanvasGroup target) {
		target.alpha = 1;
		target.interactable = true;
		target.blocksRaycasts = true;
	}

	public static void hide(CanvasGroup target) {
		target.alpha = 0;
		target.interactable = false;
		target.blocksRaycasts = false;
	}

	public static void toggle(CanvasGroup target) {
		target.alpha = target.alpha==0?1:0;
		target.interactable = !target.interactable;
		target.blocksRaycasts = !target.blocksRaycasts;
	}
}
