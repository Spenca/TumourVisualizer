// credit to https://gist.github.com/JISyed/5017805

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth

	private Vector3 mouseOrigin;		// Position of cursor when mouse dragging starts
	private bool isPanning;				// Is the camera being panned?
	private bool isRotating;			// Is the camera being rotated?
	private bool isZooming;				// Is the camera zooming?

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Get the left mouse button
		if (Input.GetMouseButtonDown(0)) {

			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}

		// Get the right mouse button
		if (Input.GetMouseButtonDown(1)) {

			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}

		// Get the space key
		if (Input.GetKeyDown(KeyCode.Space)) {

			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}

		// Disable movements on button/key release
		if (!Input.GetMouseButton(0)) isRotating = false;
		if (!Input.GetMouseButton(1)) isPanning = false;
		if (Input.GetKeyUp(KeyCode.Space)) isZooming = false;

		// Rotate the camera along X and Y axis
		if (isRotating) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}

		// Move the camera on its XY plane
		if (isPanning) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}

		// Move the camera linearly along Z axis
		if (isZooming) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = pos.y * zoomSpeed * transform.forward; 
			transform.Translate(move, Space.World);
		}
	}
}
