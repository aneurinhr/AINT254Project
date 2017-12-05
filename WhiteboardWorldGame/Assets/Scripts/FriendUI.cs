using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendUI : MonoBehaviour {

    public int friends = 0;

	public void UpdateUI () {
        friends = friends - 1;
        gameObject.GetComponent<Text>().text = "" + friends;
	}
}
