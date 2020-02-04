using UnityEngine.UI;
using UnityEngine;

public class HungerHandler : MonoBehaviour
{
    #region SINGLETON SETUP
    public static HungerHandler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private int _maxHunger = 100;
    private int _currentHunger = 100;
    private int _baseHungerLoss = 1;
    public int EnergyGainFromEating = 5;
    public int HungerGainFromEating = 25;
    private float _decreaseRateInSeconds = 1.0f;//Every X seconds, they will lose _baseHungerLoss of hunger
    public Slider HungerBar;
    private void Start()
    {
        HungerBar.maxValue = _maxHunger;
        HungerBar.value = _maxHunger;
        InvokeRepeating("HungerTimer", 0.0f, _decreaseRateInSeconds);
    }

    private void HungerTimer()
    {
        ReduceHunger(_baseHungerLoss);
    }

    public void IncreaseHunger(int increase)
    {
        _currentHunger += increase;
        HungerBar.value += increase;
    }

    public void ReduceHunger(int decrease)
    {
        _currentHunger -= decrease;
        HungerBar.value -= decrease;
    }
}
