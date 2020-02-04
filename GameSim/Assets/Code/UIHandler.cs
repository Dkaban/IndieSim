using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    #region SINGLETON SETUP
    public static UIHandler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Slider energyBar;

    public GameObject MakeGameUIObject;
    public GameObject ChooseGenreUIObject;
    public GameObject NameGameUIObject;
    public GameObject PauseMenuUIObject;

    public void PressSleep()
    {
        EnergyHandler.Instance.ResetEnergy();
    }

    public void PressEat()
    {
        HungerHandler.Instance.IncreaseHunger(HungerHandler.Instance.HungerGainFromEating);
        EnergyHandler.Instance.IncreaseEnergy(HungerHandler.Instance.EnergyGainFromEating);
    }

    public void PressMakeGame()
    {
        MakeGameUIObject.SetActive(false);
        ChooseGenreUIObject.SetActive(true);
    }

    public void SetEnergy(float val)
    {
        energyBar.maxValue = val;
        energyBar.value = energyBar.maxValue;
    }

    public void ReduceEnergyBar(float value)
    {
        energyBar.value -= value;
    }

    public void IncreaseEnergyBar(float value)
    {
        energyBar.value += value;
        if(energyBar.value > energyBar.maxValue)
        {
            energyBar.value = energyBar.maxValue;
        }
    }
}
