using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] int maxEnergy = 50;
    [SerializeField] float energy = 0;
    [SerializeField] Slider energySlider;
    [SerializeField] float energyRegen;

    private void Start()
    {
        energy = maxEnergy;
        energySlider.value = ((float)this.energy) / maxEnergy;
    }
    private void Update()
    {
        AddEnergy(energyRegen * Time.deltaTime);
    }
    public bool IsFullShieldHp()
    {
        if (energy >= maxEnergy)
            return true;
        else
            return false;
    }
    public void AddEnergy(float amount)
    {
        energy += amount;
        energy = Mathf.Clamp(energy, 0f, maxEnergy);
        energySlider.value = (energy) / maxEnergy;
    }
    public bool TrySpendEnergy(float amount)
    {
        if (energy > amount)
        {
            energy -= amount;
            energySlider.value = (energy) / maxEnergy;
            if (energy <= 0)
            {
                energy = 0;
                energySlider.value = (energy) / maxEnergy;
            }
            return true;
        }
        return false;
    }
}
