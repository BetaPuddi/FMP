﻿using UnityEngine;

namespace PlayerInput
{
	public class MouseLook : MonoBehaviour
	{
		[SerializeField] private float sensitivityX = 8f;
		[SerializeField] private float sensitivityY = 0.5f;
		private float mouseX, mouseY;
	
		[SerializeField] private Transform playerCamera;
		[SerializeField] private float xClamp = 85f;
		private float xRotation = 0f;
	
		// Update is called every frame, if the MonoBehaviour is enabled.
		protected void Update()
		{
			transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
		
			xRotation -= mouseY;
			xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
			Vector3 targetRotation = transform.eulerAngles;
			targetRotation.x = xRotation;
			playerCamera.eulerAngles = targetRotation;
		}
	
		public void ReceiveInput (Vector2 mouseInput)
		{
			mouseX = mouseInput.x * sensitivityX;
			mouseY = mouseInput.y * sensitivityY;
		}
	
	}
}
