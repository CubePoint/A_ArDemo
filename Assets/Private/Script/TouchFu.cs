using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFu : MonoBehaviour {

	[SerializeField]
	private float needtm;
	private float timing;
	private Vector3 startScale;
	private SpriteRenderer srender;
	private CircleCollider2D ccollider2d;
	[SerializeField]
	private ParticleSystem fireparticle;

	void Start() {
		srender = GetComponent<SpriteRenderer> ();
		ccollider2d = GetComponent<CircleCollider2D>();
		timing = 0;
		startScale = new Vector3 (0, 0, 1);
	}

		
	// Update is called once per frame
	void Update () {
		if (!srender.enabled) {
			
		} else {
			timing += Time.deltaTime;
			transform.localScale = Vector3.Lerp (startScale, Vector3.one, timing / needtm);

		}
	}

	void OnMouseDown() {
		if (transform.localScale != Vector3.one)
			return;
		fireparticle.Play ();
		ccollider2d.enabled = false;
		Invoke ("catchshow",1.5f);
	}

	void catchshow() {
		CatchOne.Instant.show ();
	}
		

	public void OnTrackingFound() {
		timing = 0;
		ccollider2d.enabled = true;
	}
	public void OnTrackingLost() {
	}
}
