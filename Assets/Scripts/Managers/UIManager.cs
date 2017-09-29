using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Defining the targeted health slider
    private Slider healthSlider;
    private CanvasRenderer healthSliderFill;
    private CanvasRenderer healthSliderBackground;


    // Defining the targeted energy slider
    private Slider energySlider;
    private CanvasRenderer energySliderFill;
    private CanvasRenderer energySliderBackground;


    private void Start() {
        healthSlider = GameObject.FindWithTag("healthSlider").GetComponent<Slider>();
        healthSliderFill = GameObject.FindWithTag("healthSliderFill").GetComponent<CanvasRenderer>();
        healthSliderBackground = GameObject.FindWithTag("healthSliderBackground").GetComponent<CanvasRenderer>();

        energySlider = GameObject.FindWithTag("energySlider").GetComponent<Slider>();
        energySliderFill = GameObject.FindWithTag("energySliderFill").GetComponent<CanvasRenderer>();
        energySliderBackground = GameObject.FindWithTag("energySliderBackground").GetComponent<CanvasRenderer>();
    }


    public void HealthSliderUpdater(float ratioHealthCurrentOnMax) {
        healthSlider.value = ratioHealthCurrentOnMax;

        if (ratioHealthCurrentOnMax > 0.6f) {
            healthSliderFill.SetColor(Color.green);
        }
        else if (ratioHealthCurrentOnMax > 0.2f) {
            healthSliderFill.SetColor(Color.yellow);
        }
        else {
            healthSliderFill.SetColor(Color.red);
        }

        healthSliderBackground.SetColor(Color.grey);
    }


    public void EnergySliderUpdater(float ratioEnergyCurrentOnMax) {
        energySlider.value = ratioEnergyCurrentOnMax;

        if (ratioEnergyCurrentOnMax >= 1f) {
            energySliderFill.SetColor(Color.white);
        }
        else if (ratioEnergyCurrentOnMax < 0f) {
            energySliderFill.SetColor(Color.red);
        }

        energySliderBackground.SetColor(Color.grey);
    }
}
