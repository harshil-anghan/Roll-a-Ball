using UnityEngine;
using System.Collections;

public enum SwipeDirection
{
	None = 0,
	Left = 1,
	Right = 2,
	Up = 4,
	Down = 8,
}

public class SwipeManager : MonoBehaviour 
{
	private static SwipeManager instance;
	public static SwipeManager Instance{get{return instance;}}
	public SwipeDirection Direction{set;get;}
	private Vector3 touchPosition;
	private float swipeResistanceX = 250.0f;
	private float swipeResistanceY = 100.0f;
	int planemask;
	int planemask1;
	void Start()
	{
		instance = this;
		planemask = LayerMask.GetMask("Default");
		planemask1 = LayerMask.GetMask("Floor");

	}
		
	private void Update()
	{
		Direction = SwipeDirection.None;
		Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if(Physics.Raycast(camray , out hit , 100000000 , planemask) || Physics.Raycast(camray , out hit , 100000000 , planemask1))
		{
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(1))
		{
			touchPosition = Input.mousePosition;
		}

		if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
		{
			Vector2 deltaSwipe = touchPosition - Input.mousePosition;

			if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
			{
				Direction |= (deltaSwipe.x < 0)		? SwipeDirection.Right : SwipeDirection.Left;
			}

			if(Mathf.Abs(deltaSwipe.y) > swipeResistanceY)
			{
				Direction |= (deltaSwipe.y < 0)		? SwipeDirection.Up : SwipeDirection.Down;
			}
		}
		}
	}

	public bool isSwiping(SwipeDirection dir)
	{
		return(Direction & dir) == dir;
	}

}
