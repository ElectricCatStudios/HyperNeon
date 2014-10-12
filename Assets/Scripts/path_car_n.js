#pragma strict

var speed: float;
private var numberOfPoints : int;
var waypoints : Transform[] = new Transform[numberOfPoints];
private var transition = 0;

private var waypointsBegin = true;
 
function Start () {
}

function Update () {
	
	var step = speed * Time.deltaTime;
	
	//Begin loop
	if(waypointsBegin)
	{
		
		transform.LookAt(waypoints[0]);
		transform.position = Vector3.MoveTowards(transform.position, waypoints[0].position, step);
		
		if(transform.position == waypoints[0].position)
		{
			waypointsBegin = false;
			transition++;
		}
	}
	else
	{	
		if(!waypointsBegin)
		{
			transform.LookAt(waypoints[transition]);
			transform.position = Vector3.MoveTowards(transform.position, waypoints[transition].position, step);
			
			if(transform.position == waypoints[transition].position)
			{
				transition++;
			}
		}
		//When end of points array is hit, restart loop
		if(transition == waypoints.Length)
		{
			waypointsBegin = true;
			transition = 0;
		}
	}
}