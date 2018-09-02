using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Camera Camera;
	[SerializeField]
	private FloatReference MinCameraDistance;
	[SerializeField]
	private FloatReference MaxCameraDistance;
	[SerializeField]
	private FloatReference ZoomSensitivity;
	[SerializeField]
	private FloatReference MouseRotationSensitivity;
	[SerializeField]
	private FloatReference MousePanSensitivity;

	private Vector3 m_groundPoint;

	private void LateUpdate()
	{
		// Scroll
		var distanceToGround = DistanceToGround();
		var scrollValue = -Input.GetAxis("Mouse ScrollWheel");
		if (distanceToGround > MinCameraDistance.Value && scrollValue > 0 || distanceToGround < MaxCameraDistance.Value && scrollValue < 0)
		{
			Camera.transform.position += Camera.transform.forward * scrollValue * ZoomSensitivity.Value;
		}

		// Drag
		if (Input.GetMouseButton(0))
		{
			var mouseX = Input.GetAxis("Mouse X");
			var mouseZ = Input.GetAxis("Mouse Y");
			var position = Camera.transform.position;
			var forward = transform.forward;
			forward.y = 0;
			position -= mouseX * transform.right * Time.deltaTime * MousePanSensitivity.Value;
			position -= mouseZ * forward * Time.deltaTime * MousePanSensitivity.Value;
			transform.position = position;
		}

		// Rotate
		if (Input.GetMouseButtonDown(1))
		{
			m_groundPoint = GroundPoint();
		}
		if (Input.GetMouseButton(1))
		{
			var mouseX = Input.GetAxis("Mouse X");
			transform.RotateAround(m_groundPoint, Vector3.up, mouseX * Time.deltaTime * MouseRotationSensitivity.Value);
		}
	}

	private float DistanceToGround()
	{
		RaycastHit hit;
		var ray = new Ray(Camera.transform.position, Camera.transform.forward);
		if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Ground")))
		{
			return (hit.point - Camera.transform.position).magnitude;
		}

		return 0f;
	}

	private Vector3 GroundPoint()
	{
		RaycastHit hit;
		var ray = new Ray(Camera.transform.position, Camera.transform.forward);
		if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Ground")))
		{
			return hit.point;
		}

		return Vector3.zero;
	}
}