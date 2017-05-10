using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {
	public float scaleFactor;
	Material mat;

	void Awake() {
		scaleFactor = 1.0f;
	}

	void Start() {
		GetComponent<SpriteRenderer> ().material.mainTextureScale = new Vector2 (transform.localScale.x / scaleFactor, transform.localScale.y / scaleFactor);
	}

	void Update() {
		if (transform.hasChanged && Application.isEditor && !Application.isPlaying) {
			GetComponent<SpriteRenderer> ().material.mainTextureScale = new Vector2 (transform.localScale.x / scaleFactor, transform.localScale.y / scaleFactor);
			transform.hasChanged = false;
		}
	}
}