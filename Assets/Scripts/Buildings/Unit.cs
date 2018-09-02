public class Unit : Entity
{
	public override void Click()
	{
		EventManager.TriggerEvent(EntityEventType.Click, this);
	}

	public override void TriggerButtonPress(Entity entity)
	{
		if (!(entity is Building))
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Only building have build support");
			return;
		}

		EventManager.TriggerEvent(BuildingEventType.ButtonPress, (Building)entity);
	}
}