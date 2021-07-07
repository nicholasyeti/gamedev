using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider StaminaBarx;

    public int maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        StaminaBarx.maxValue = maxStamina;
        StaminaBarx.value = maxStamina;
    }

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            StaminaBarx.value = currentStamina;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            StaminaBarx.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
   
}

