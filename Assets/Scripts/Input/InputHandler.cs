using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	public static InputHandler instance;

	private PlayerInput controls;

	//Grabs the empty game object for the pause menu screen
	public GameObject PauseMenu;

	[Header("Input Values")]
	public Action<InputArgs> OnJumpPressed;
	public Action<InputArgs> OnJumpReleased;
	public Action<InputArgs> OnDash;

	[SerializeField] private HarpoonClass _harpoon;

	public Vector2 MoveInput { get; private set; }
	public float ClimbInput { get; private set; }

	public bool isPaused = false;


	private void Awake()
	{

		#region Singleton
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		#endregion

		controls = new PlayerInput();

		#region Assign Inputs
		controls.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
		controls.Player.Movement.canceled += ctx => MoveInput = Vector2.zero;

		controls.Player.Jump.performed += ctx => OnJumpPressed(new InputArgs { context = ctx });
		controls.Player.JumpUp.performed += ctx => OnJumpReleased(new InputArgs { context = ctx });
		controls.Player.Dash.performed += ctx => OnDash(new InputArgs { context = ctx });

		controls.Player.Climb.performed += ctx => ClimbInput = ctx.ReadValue<float>();
        controls.Player.Climb.canceled += ctx => ClimbInput = 0;
		controls.UI.Pause.performed += ctx => OnPause();


		controls.Shooting.RIGHT.performed += ctx => _harpoon.IsShootingRight();
		controls.Shooting.LEFT.performed += ctx => _harpoon.IsShootingLeft();
		controls.Shooting.DOWN.performed += ctx => _harpoon.IsShootingDown();
		controls.Shooting.UP.performed += ctx => _harpoon.IsShootingUp();
		#endregion
	}

    #region Events
    public class InputArgs
	{
		public InputAction.CallbackContext context;
	}
	#endregion

	#region OnEnable/OnDisable
	private void OnEnable()
	{
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Disable();
	}
	#endregion

	//Toggles the pause menu scren 
	public void OnPause()
    {

		if(isPaused == false)
        {
			PauseMenu.SetActive(false);
			isPaused = true;
		
			Time.timeScale = 1f;
		}
		else if(isPaused == true)
        {
			PauseMenu.SetActive(true);
			isPaused = false;
			Time.timeScale = 0.0000001f;
			Debug.Log("Paused");
		}
		
    }





}

