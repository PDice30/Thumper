using UnityEngine;
using System.Collections;

public class PlayerPowerup : MonoBehaviour {

	// Use this for initialization
	public ItemType itemType;
	private Sprite sprite;

	void Start () {
		//Debug.Log (itemType);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setSprite(Sprite sprite) {
		this.sprite = sprite;
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprite;

	}
	public Sprite getSprite() {
		return sprite;
	}

	public void setItemType(ItemType itemType) {
		this.itemType = itemType;
	}
	public ItemType getItemType() {
		return itemType;
	}

}
