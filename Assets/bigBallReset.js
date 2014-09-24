#pragma strict

// Destroy everything that enters the trigger
function OnTriggerEnter (other : Collider) {
	Debug.Log("entered");
	// Move the object to (0, 0, 0)
	other.transform.position = Vector3(744.0463,6.104607, -1);
}