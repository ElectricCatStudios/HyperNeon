#pragma strict

var speed : int = 16;

function Update () {
	transform.Rotate(Vector3.back * speed * Time.deltaTime);
}