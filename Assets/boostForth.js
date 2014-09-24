#pragma strict

public var hoverForce : float;


function OnTriggerStay (other : Collider)
{
	Debug.Log("I'm IN!");
    other.rigidbody.AddForce(Vector3(0, .166, 1) * hoverForce, ForceMode.Acceleration);
}