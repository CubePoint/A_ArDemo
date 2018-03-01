using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBoxMain : MonoBehaviour {
	//史丹利模式
	private static CardBoxMain _Instant;
	public static CardBoxMain Instant {
		get { 
			if (_Instant == null)
				_Instant = FindObjectOfType<CardBoxMain> ();
			return _Instant;
		}
	}


	[SerializeField]
	private Image com_showBig;
	[SerializeField]
	private Image[] com_childImgs;
	[SerializeField]
	private int[] childNums;

	void Start() {
		load ();
		for (int i = 0; i < com_childImgs.Length; i++) {
			com_childImgs [i].GetComponentInChildren<Text> ().text = string.Format ("x{0}",childNums[i]);
		}
	}

	public Sprite get_sprite(int idx) {
		return com_childImgs [idx].sprite;
	}

	public void addo_childNum(int idx) {
		com_childImgs [idx].GetComponentInChildren<Text> ().text = string.Format ("x{0}",++childNums[idx]);
		com_childImgs [idx].GetComponent<Animation> ().Play ();
		save ();
	}

	public void open_showBig(int idx) {
		com_showBig.transform.parent.parent.gameObject.SetActive (true);
		com_showBig.sprite = com_childImgs[idx].sprite;
	}
	public void close_showBig() {
		com_showBig.transform.parent.parent.gameObject.SetActive (false);
	}



	void save() {
		PlayerPrefs.SetString ("childNums",
			string.Join(",",System.Array.ConvertAll <int,string>(childNums,((int input) => input.ToString()))));
	}
	void load() {
		if (PlayerPrefs.HasKey("childNums"))
			childNums = System.Array.ConvertAll <string,int>(PlayerPrefs.GetString("childNums").Split(','),((string input) => int.Parse(input)));
	}

}
