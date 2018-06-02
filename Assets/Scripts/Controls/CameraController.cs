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

	private Vector3 m_mousePosition;
	private Vector3 m_groundPoint;

	private void LateUpdate()
	{
		var distanceToGround = DistanceToGround();
		var scrollValue = -Input.GetAxis("Mouse ScrollWheel");
		if (distanceToGround > MinCameraDistance.Value && scrollValue > 0 || distanceToGround < MaxCameraDistance.Value && scrollValue < 0)
		{
			Camera.transform.position += Camera.transform.forward * scrollValue * ZoomSensitivity.Value;
		}

		// Drag
		if (Input.GetMouseButton(0))
		{

		}

		// Rotate
		if (Input.GetMouseButtonDown(1))
		{
			m_mousePosition = Input.mousePosition;
			m_groundPoint = GroundPoint();
		}
		if (Input.GetMouseButton(1))
		{
			var mouseX = Input.GetAxis("Mouse X");
			transform.RotateAround(m_groundPoint, Vector3.up, mouseX * Time.deltaTime * MouseRotationSensitivity.Value);
			m_mousePosition = Input.mousePosition;
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