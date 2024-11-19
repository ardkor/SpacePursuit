using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
    public bool trySpendEnergy(float amount)
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

    /*    public void DamagePlayer(int amount)
        {
            if (energy > 0)
            {
                energy -= amount;
                energySlider.value = ((float)energy) / maxEnergy;
                if (energy <= 0)
                {
                    energy = 0;
                    energySlider.value = ((float)energy) / maxEnergy;
                    energySlider.gameObject.SetActive(false);
                }
                return;
            }
            playerHp -= amount;
            hpSlider.value = ((float)playerHp) / maxPlayerHp;
            if (playerHp <= 0)
                GameOver();
        }*/
}
