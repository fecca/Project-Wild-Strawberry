using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuiltBuildings;
	[SerializeField]
	private bool ClearBuildingsOnAwake;

	private Building m_activeBuilding;

	private void Awake()
	{
		if (ClearBuildingsOnAwake)
		{
			BuiltBuildings.Items.Clear();
		}
	}

	private void FollowMouse()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1 << LayerMask.NameToLayer("Ground")))
		{
			m_activeBuilding.transform.position = hit.point;
		}
	}

	public void SelectBuilding(Building building)
	{
		m_activeBuilding = Instantiate(building);
		FollowMouse();
	}

	public void ResetBuildings()
	{
		for (int i = BuiltBuildings.Items.Count - 1; i >= 0; i--)
		{
			Destroy(BuiltBuildings.Items[i].gameObject);
		}
	}

	private void Update()
	{
		if (m_activeBuilding != null)
		{
			if (m_activeBuilding.GetState() == BuildingState.Placing)
			{
				FollowMouse();

				if (Input.GetMouseButtonDown(0))
				{
					m_activeBuilding.Place();
					m_activeBuilding = null;
				}

				if (Input.GetMouseButtonUp(1))
				{
					Destroy(m_activeBuilding.gameObject);
					m_activeBuilding = null;
				}
			}

			return;
		}
	}

	private void InstantiateAllBuildings()
	{
		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var building = Instantiate(AllBuildings.Value[i]);
			building.gameObject.SetActive(false);
		}
	}
}