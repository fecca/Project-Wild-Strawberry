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
	private FloatReference ZoomSpeed;

	private void LateUpdate()
	{
		var distanceToGround = DistanceToGround();
		var scrollValue = -Input.GetAxis("Mouse ScrollWheel");
		if (distanceToGround > MinCameraDistance.Value && scrollValue > 0 || distanceToGround < MaxCameraDistance.Value && scrollValue < 0)
		{
			Camera.transform.position += Camera.transform.forward * scrollValue * ZoomSensitivity.Value;
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
}