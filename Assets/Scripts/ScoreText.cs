using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//applied to 'Gems' in canvas
public class ScoreText : MonoBehaviour {

    Text text;
    public static int coinAmount;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = coinAmount.ToString();
	}
}
