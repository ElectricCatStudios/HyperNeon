#pragma strict

var detectObject : Transform;

function Start () {

}

function Update () {
	//if(transform.)
}

function OnTriggerEnter (other : Collider) {
	Destroy(other.gameObject);
}