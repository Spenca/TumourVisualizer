// shout-out to my homie: https://github.com/GraemeClarke

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		var sceneTotal = SceneManager.sceneCountInBuildSettings;

		if (Input.GetKeyDown ("up")) {

			if (sceneIndex == sceneTotal - 1) {
				sceneIndex = 0;
			} else {
				sceneIndex += 1;
			}

			SceneManager.LoadScene(sceneIndex);
		
		} else if (Input.GetKeyDown ("down")) {

			if (sceneIndex == 0) {
				sceneIndex = sceneTotal - 1;
			} else {
				sceneIndex -= 1;
			}

			SceneManager.LoadScene(sceneIndex);
		}
	}
}
