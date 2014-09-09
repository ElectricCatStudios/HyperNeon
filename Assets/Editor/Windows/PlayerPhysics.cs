using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerPhysics : EditorWindow
{	
	private string[] interpolateOptions = new string[3] {"None", "Interpolate", "Extrapolate"};
	private int interpolateIndex;
	private bool showAdvanced;
	private Rigidbody playerRigidbody;
	private Movement playerMovement;
	private PhysicMaterial playerPMat;
		
		
		// add menu item to the window menu called Player Physics
	[MenuItem("Window/Player Physics")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow (typeof(PlayerPhysics));
	}

	void OnEnable()
	{
		// get relevant components
		playerRigidbody = GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ();
		playerMovement = GameObject.FindWithTag ("Player").GetComponent<Movement> ();
		playerPMat = (PhysicMaterial) Resources.Load ("PhysicMaterials/Ball");
	}

	void OnInspectorUpdate()
	{
		Repaint ();
	}
	
	void OnGUI()
	{
		// MOVEMENT SETTINGS
		GUILayout.Label ("Movement Settings", EditorStyles.boldLabel);
		// force
		playerMovement.forceCoeff = EditorGUILayout.FloatField ("Force Magnitude", playerMovement.forceCoeff);
		// torque
		playerMovement.torqueCoeff = EditorGUILayout.FloatField ("Torque Magnitude", playerMovement.torqueCoeff);
		// jump force
		playerMovement.jumpCoeff = EditorGUILayout.FloatField ("Jump Magnitude", playerMovement.jumpCoeff);
		// jump margin
		playerMovement.jumpMargin = EditorGUILayout.FloatField ("Jump Margin", playerMovement.jumpMargin);
		// jump detection sphere radius
		playerMovement.jumpDetRad = EditorGUILayout.FloatField ("Jump Detection Radius", playerMovement.jumpDetRad);

		// RIGIDBODY SETTINGS
		GUILayout.Label ("Rigidbody Settings", EditorStyles.boldLabel);
		// gravity
		Physics.gravity = Vector3.down * EditorGUILayout.FloatField("Gravity Magnitude", -Physics.gravity.y);
		// mass
		playerRigidbody.mass = EditorGUILayout.FloatField("Mass", playerRigidbody.mass);
		// drag
		playerRigidbody.drag = EditorGUILayout.FloatField("Drag", playerRigidbody.drag);
		playerRigidbody.angularDrag = EditorGUILayout.FloatField("Angular Drag", playerRigidbody.angularDrag);
		// max angular velocity
		playerMovement.maxAngularVel = EditorGUILayout.FloatField("Max Angular Velocity", playerMovement.maxAngularVel);
		playerRigidbody.maxAngularVelocity = playerMovement.maxAngularVel;

		// PHYSICS MATERIAL SETTINGS
		GUILayout.Label ("Physics Material Settings", EditorStyles.boldLabel);
		// friction
		playerPMat.dynamicFriction = EditorGUILayout.FloatField ("Dynamic Friction", playerPMat.dynamicFriction);
		playerPMat.staticFriction = EditorGUILayout.FloatField ("Static Friction", playerPMat.staticFriction);
		// bounciness
		playerPMat.bounciness = EditorGUILayout.FloatField ("Bounciness", playerPMat.bounciness);

		// ADVANCED SETTINGS
		showAdvanced = EditorGUILayout.Foldout (showAdvanced, "Advanced Settings");
		if (showAdvanced) {
			// cone friction
			playerMovement.useConeFriction = EditorGUILayout.Toggle ("\tUse Cone Friction", playerMovement.useConeFriction);
			playerRigidbody.useConeFriction = playerMovement.useConeFriction;
			// interpolation
			interpolateIndex = EditorGUILayout.Popup ("\tInerpolation", interpolateIndex, interpolateOptions);
			switch (interpolateIndex) {
			case 0:
					playerRigidbody.interpolation = RigidbodyInterpolation.None;
					playerMovement.interpolation = RigidbodyInterpolation.None;
					break;
			case 1:
					playerRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
					playerMovement.interpolation = RigidbodyInterpolation.Interpolate;
					break;
			case 2:
					playerRigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
					playerMovement.interpolation = RigidbodyInterpolation.Extrapolate;
					break;
			}
			// iteration count
			playerMovement.iterationCount = EditorGUILayout.IntField ("\tSolver Iteration Count", playerMovement.iterationCount);
			playerRigidbody.solverIterationCount = playerMovement.iterationCount;
		}
	}
}


