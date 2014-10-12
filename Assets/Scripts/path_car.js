#pragma strict

var point1 : Transform;
var point2 : Transform;
var point3 : Transform;
var speed: float;

private var visited_p1 = false;
private var visited_p2 = false;
private var visited_p3 = false;
 
function Start () {

}

function Update () {
	
	var step = speed * Time.deltaTime;
	
	if(!visited_p1)
	{
		transform.LookAt(point1);
		transform.position = Vector3.MoveTowards(transform.position, point1.position, step);
		
		if(transform.position == point1.position)
		{
			visited_p1 = true;
		}
	}
	
	if(visited_p1 &&
		!visited_p2)
	{
		transform.LookAt(point2);
		transform.position = Vector3.MoveTowards(transform.position, point2.position, step);
		
		if(transform.position == point2.position)
		{
			visited_p2 = true;
		}
	}
	
	if(visited_p1 &&
		visited_p2 &&
		!visited_p3)
	{
		transform.LookAt(point3);
		transform.position = Vector3.MoveTowards(transform.position, point3.position, step);
		
		//Reset loop
		if(transform.position == point3.position)
		{
			visited_p1 = false;
			visited_p2 = false;
		}
	}
}