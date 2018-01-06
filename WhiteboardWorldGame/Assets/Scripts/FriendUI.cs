using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendUI : MonoBehaviour {

    public int friends = 0;
    private int FullFriends;

    private void Start()
    {
        FullFriends = friends;
    }

    public void UpdateUI() {
        friends = friends - 1;
        gameObject.GetComponent<Text>().text = "" + friends;
	}

    public void ResetFriends()
    {
        friends = FullFriends;
        gameObject.GetComponent<Text>().text = "" + friends;
    }
}
