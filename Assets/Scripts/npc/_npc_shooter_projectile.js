#pragma strict

private var start : float;
var projectileTimeout : float = 3;

function Start () {
	start = Time.time;
}

function Update () {

	if(Time.time - start >= projectileTimeout)
	{
		Destroy(this.gameObject);
	}
}