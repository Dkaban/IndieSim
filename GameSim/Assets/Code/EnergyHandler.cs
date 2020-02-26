using UnityEngine;
using UnityEngine.UI;

public class EnergyHandler : MonoBehaviour
{
    #region SINGLETON SETUP
    public static EnergyHandler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Slider EnergyBar;

    #region Energy Variables
    private const int MaxEnergy = 100; //In seconds (etc 100 seconds)
    private int _currentEnergy = 100;
    private const int BaseEnergyLoss = 1;
    private const float DecreaseRateInSeconds = 5.0f;//Every X seconds, they will lose _baseEnergyLoss amount
    #endregion

    private void Start()
    {
        EnergyBar.maxValue = MaxEnergy;
        EnergyBar.value = MaxEnergy;
        InvokeRepeating("EnergyTimer", 0, DecreaseRateInSeconds);
    }

    private void EnergyTimer()
    {
        DecreaseEnergy(BaseEnergyLoss);
    }

    public void IncreaseEnergy(int increase)
    {
        _currentEnergy += increase;
        EnergyBar.value += increase;

        if (_currentEnergy > MaxEnergy)
        {
            _currentEnergy = MaxEnergy;
            EnergyBar.value = MaxEnergy;
        }
    }

    public void DecreaseEnergy(int decrease)
    {
        _currentEnergy -= decrease;
        EnergyBar.value -= decrease;
    }

    public void ResetEnergy()
    {
        _currentEnergy = MaxEnergy;
        EnergyBar.value = MaxEnergy;
    }
}
