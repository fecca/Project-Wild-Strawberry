public class Unit : Entity
{
	public override void Click()
	{
		Select(true);
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