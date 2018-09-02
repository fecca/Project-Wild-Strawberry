using UnityEngine;

public class EntityManager : MonoBehaviour
{
	[SerializeField]
	protected BuildingManager BuildingManager;
	[SerializeField]
	protected UnitManager UnitManager;

	private Entity m_selectedEntity;

	public void OnClick(Entity entity)
	{
		if (m_selectedEntity != null)
		{
			m_selectedEntity.Select(false);
		}
		m_selectedEntity = entity;
		if (m_selectedEntity != null)
		{
			m_selectedEntity.Click();
		}
	}
}