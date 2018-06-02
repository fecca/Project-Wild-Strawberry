public class BuildingPlacementValidator : Validator
{
	public int Collisions { get; set; }

	private BuildingBounds[] BuildingBounds;

	private void OnEnable()
	{
		BuildingBounds = GetComponentsInChildren<BuildingBounds>();
		foreach (var buildingBounds in BuildingBounds)
		{
			buildingBounds.Initialize(this);
		}
	}

	public override bool Validate()
	{
		return Collisions == 0;
	}
}