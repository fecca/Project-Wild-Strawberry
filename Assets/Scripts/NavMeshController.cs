using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
	[SerializeField]
	private NavMeshSurface Surface;

	public void BakeSurface()
	{
		Surface.BuildNavMesh();
	}
}