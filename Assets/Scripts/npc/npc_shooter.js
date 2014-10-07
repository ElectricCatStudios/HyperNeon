#pragma strict

var target : Transform;
var attackDistance = 5;
var rotateSpeed : float;
var FOV : int;
var projectile : GameObject;
var attackSpeed : float;
var projectileForce : float = 2000;
private var nextAttack : float;

function Start () {
	nextAttack = attackSpeed * 2;
}

function Update () {

	if(LineOfSight(target))
	{
		var targetDirection = target.position - transform.position;
		var step = rotateSpeed * Time.deltaTime;
		var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0);
		
		transform.rotation = Quaternion.LookRotation(newDirection);
		
		//Makes sure the next shot will be timed correctly
		if(Time.time > nextAttack)
		{
			nextAttack = Time.time + attackSpeed;
			LaunchProjectile();
		}
	}
}

function LaunchProjectile()
{
	var projectile = Instantiate(projectile, transform.position, transform.rotation);
	projectile.rigidbody.AddForce(transform.forward * projectileForce);
}

//implements a field of view condition
function LineOfSight(target : Transform) : boolean {
	var hit : RaycastHit;

	if(	Physics.Linecast(transform.position, target.position, hit) &&
		hit.collider.transform == target &&
		Vector3.Angle(target.position - transform.position, transform.forward) <= FOV)
	{
		return true;
	}
	else
	{
		return false;
	}
}