public class Fuel : Item
{
    public float fuelAddAmount;
    public override void OnItemAcquired(PlayerController player)
    {
        player.AdjustFuelAmount(fuelAddAmount);
    }
}
