using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{
		private float x = 0.0f;
		private float y = 0.0f;
		private float distance1 = 5.0f;

		// The target we are following
		[SerializeField]
		//private Transform target;
		public Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 20.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;
		private Vector3 offset;
		private float yoffset = 10.0f;


		// Use this for initialization
		void Start() {
			//target = GameObject.Find("Player");
			Vector3 angels = transform.eulerAngles;
			x = angels.y;
			y = angels.x;
			offset = new Vector3(0,yoffset,-1f * distance);
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			if(Input.GetMouseButton(1))
			{
				x += Input.GetAxis("Mouse X") * distance1;
				y -= Input.GetAxis("Mouse Y") * distance1;
				Quaternion rotation = Quaternion.Euler(y,x,0);
				transform.rotation = rotation;
			}
		}
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			// Calculate the current rotation angles
			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);
		}
	}
}