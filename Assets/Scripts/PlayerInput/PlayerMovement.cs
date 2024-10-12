using UnityEngine;

namespace PlayerInput
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private CharacterController controller;
		[SerializeField] private float speed = 11f;

		private Vector2 horizontalInput;

		[SerializeField] private float jumpHeight = 3.5f;
		private bool isJumping;
		[SerializeField] private float gravity = -30f; // -9.81
		private Vector3 verticalVelocity = Vector3.zero;
		[SerializeField] private LayerMask groundMask;
		[SerializeField] private bool isGrounded;

		// Update is called every frame, if the MonoBehaviour is enabled.
		protected void Update()
		{
			float halfHeight = controller.height * 0.5f;

			var bottomPoint = transform.TransformPoint(controller.center - Vector3.up * halfHeight);

			isGrounded = Physics.CheckSphere(bottomPoint, 0.1f, groundMask);
			if (isGrounded)
			{
				verticalVelocity.y = 0;
			}

			Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
			controller.Move(horizontalVelocity * Time.deltaTime);

			if (isJumping)
			{
				if (isGrounded)
				{
					verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
				}
				isJumping = false;
			}

			verticalVelocity.y += gravity * Time.deltaTime;
			controller.Move(verticalVelocity * Time.deltaTime);
		}

		public void ReceiveInput (Vector2 _horizontalInput)
		{
			horizontalInput = _horizontalInput;
			print(horizontalInput);
		}

		public void OnJumpPressed()
		{
			isJumping = true;
		}
	}
}
