namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerFuel
    {
        public bool IsEmpty { get; }
        void UpdateGameStartingFuel(float fuelValue);
        void DecreaseFuel(float amount);
        void ShipExplosionDecreaseFuel();
        float GameStartingFuel { get; }
        float CurrentFuel { get; }

    }
}