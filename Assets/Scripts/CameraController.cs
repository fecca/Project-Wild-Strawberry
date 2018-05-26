using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Camera Camera;
	[SerializeField]
	private FloatReference MaxZoomFieldOfView;
	[SerializeField]
	private FloatReference MinZoomFieldOfView;
	[SerializeField]
	private FloatReference ZoomSensitivity;
	[SerializeField]
	private FloatReference ZoomSpeed;

	private float zoomPos = 0;

	private void LateUpdate()
	{
		var distanceToGround = DistanceToGround();
		zoomPos += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomSensitivity.Value;
		zoomPos = Mathf.Clamp01(zoomPos);

		var targetHeight = Mathf.Lerp(MinZoomFieldOfView.Value, MaxZoomFieldOfView.Value, zoomPos);
		var difference = 0f;

		if (distanceToGround != targetHeight)
		{
			difference = targetHeight - distanceToGround;
		}

		Camera.transform.position = Vector3.Lerp(Camera.transform.position, new Vector3(Camera.transform.position.x, targetHeight + difference, Camera.transform.position.z), Time.deltaTime * ZoomSpeed.Value);
	}

	private float DistanceToGround()
	{
		RaycastHit hit;
		var ray = new Ray(Camera.transform.position, Camera.transform.forward);
		if (Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("Ground")))
		{
			return (hit.point - Camera.transform.position).magnitude;
		}

		return 0f;
	}
}