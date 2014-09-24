#pragma strict

var speed : int = 48;

function Update () {
	transform.Rotate(Vector3.forward * speed * Time.deltaTime);
}