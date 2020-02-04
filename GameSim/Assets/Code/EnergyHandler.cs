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
    private int _maxEnergy = 100; //In seconds (etc 100 seconds)
    private int _currentEnergy = 100;
    private int _baseEnergyLoss = 1;
    private float _decreaseRateInSeconds = 5.0f;//Every X seconds, they will lose _baseEnergyLoss amount
    #endregion

    private void Start()
    {
        EnergyBar.maxValue = _maxEnergy;
        EnergyBar.value = _maxEnergy;
        InvokeRepeating("EnergyTimer", 0, _decreaseRateInSeconds);
    }

    private void EnergyTimer()
    {
        DecreaseEnergy(_baseEnergyLoss);
    }

    public void IncreaseEnergy(int increase)
    {
        _currentEnergy += increase;
        EnergyBar.value += increase;

        if (_currentEnergy > _maxEnergy)
        {
            _currentEnergy = _maxEnergy;
            EnergyBar.value = _maxEnergy;
        }
    }

    public void DecreaseEnergy(int decrease)
    {
        _currentEnergy -= decrease;
        EnergyBar.value -= decrease;
    }

    public void ResetEnergy()
    {
        _currentEnergy = _maxEnergy;
        EnergyBar.value = _maxEnergy;
    }
}
