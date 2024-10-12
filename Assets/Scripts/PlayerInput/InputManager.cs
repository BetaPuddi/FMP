using UnityEngine;

namespace PlayerInput
{
	public class InputManager : MonoBehaviour
	{
		[SerializeField] private PlayerMovement playerMovement;
		[SerializeField] private MouseLook mouseLook;
		[SerializeField] private CombatInput combatInput;

		private MiniDungeon controls;
		private MiniDungeon.PlayerActions playerActions;

		private Vector2 horizontalInput;
		private Vector2 mouseInput;

		// Awake is called when the script instance is being loaded.
		protected void Awake()
		{
			controls = new MiniDungeon();
			playerActions = controls.Player;

			playerActions.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

			playerActions.MouseLookX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
			playerActions.MouseLookY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();	
			
			playerActions.Jump.performed += _ => playerMovement.OnJumpPressed();
			playerActions.CastMagic.performed += _ => combatInput.MagicUsed();
		}

		// Update is called every frame, if the MonoBehaviour is enabled.
		protected void Update()
		{
			playerMovement.ReceiveInput(horizontalInput);
			mouseLook.ReceiveInput(mouseInput);
		}

		// This function is called when the object becomes enabled and active.
		protected void OnEnable()
		{
			controls.Enable();
		}

		// This function is called when the behaviour becomes disabled () or inactive.
		protected void OnDisable()
		{
			controls.Disable();
		}
	}
}
