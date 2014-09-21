#pragma strict

var speed : int = 25;

function Update() {
	// Slowly rotate the object around its X axis at 1 degree/second.
	//transform.Rotate(Vector3.right * Time.deltaTime);
	// ... at the same time as spinning relative to the global 
	// Y axis at the same speed.
	transform.Rotate(Vector3.right * Time.deltaTime * speed);
	//Quaternion.AngleAxis(Mathf.PingPong(Time.time, 120), Vector3.up);
}