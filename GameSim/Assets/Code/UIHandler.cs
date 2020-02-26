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

    public Slider EnergyBar;

    public GameObject MakeGameUiObject;
    public GameObject ChooseGenreUiObject;
    public GameObject NameGameUiObject;
    public GameObject PauseMenuUiObject;

    public void PressSleep()
    {
        EnergyHandler.Instance.ResetEnergy();
    }

    public void PressMakeGame()
    {
        MakeGameUiObject.SetActive(false);
        ChooseGenreUiObject.SetActive(true);
    }

    public void SetEnergy(float val)
    {
        EnergyBar.maxValue = val;
        EnergyBar.value = EnergyBar.maxValue;
    }

    public void ReduceEnergyBar(float value)
    {
        EnergyBar.value -= value;
    }

    public void IncreaseEnergyBar(float value)
    {
        EnergyBar.value += value;
        if(EnergyBar.value > EnergyBar.maxValue)
        {
            EnergyBar.value = EnergyBar.maxValue;
        }
    }
}
