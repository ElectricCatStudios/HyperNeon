#pragma strict

var target : Transform;
var attackDistance = 5;
var speed: float;
var goesHome = false;
var textureAngry : Texture;
private var textureHappy : Texture;
private var originalPosition : Vector3;
private var originalRot: Quaternion;

var _debug = false;
private var _debugInAttackRadius = false;

function Start () {
	//save its original position and rotation in the world
	originalPosition = transform.position;
	originalRot = transform.rotation;
	textureHappy = renderer.material.mainTexture;
}

function Update () {

	var distance = Vector3.Distance(transform.position, target.transform.position);
	var step = speed * Time.deltaTime;
	
	if(LineOfSight(target) &&
		distance <= attackDistance)
	{		
		//modify the target position height so the rammer wont clip through the ground
		var targetMod = Vector3(target.position.x, target.position.y + 0.35, target.position.z);
		
		transform.LookAt(targetMod);
		transform.position = Vector3.MoveTowards(transform.position, targetMod, step);
		
		if(renderer.material.mainTexture != textureAngry)
		{
			renderer.material.mainTexture = textureAngry;
		}
		
		//Debug
		if(_debug && !_debugInAttackRadius)
		{
			Debug.Log("In attack radius. (" + name + ")");
			_debugInAttackRadius = true;
		}
	}
	else
	{
		if(renderer.material.mainTexture != textureHappy)
		{
			renderer.material.mainTexture = textureHappy;
		}
		
		//If the conditions are true, the rammer will return to its original location
		if(goesHome &&
			transform.position != originalPosition)
		{
			transform.LookAt(originalPosition);
			transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);
		}
		
		//Returns the rammer to its original rotation when it arrives home
		if(transform.position == originalPosition &&
			transform.rotation != originalRot)
		{
			transform.rotation = originalRot;
		}
		
		//Debug
		if(_debug && _debugInAttackRadius)
		{
			Debug.Log("Outside attack radius. (" + name + ")");
			_debugInAttackRadius = false;
		}
	}
}

//360 LoS
//note: specific LoS line in IF -- Vector3.Angle(target.position - transform.position, transform.forward) <= fov
function LineOfSight(target : Transform) : boolean {
	var hit : RaycastHit;

	if(	Physics.Linecast(transform.position, target.position, hit) &&
		hit.collider.transform == target)
	{
		return true;
	}
	else
	{
		return false;
	}
}