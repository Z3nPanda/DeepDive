using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOperator : MonoBehaviour
{
    private static Image HealthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
    }

    // sets the health bar value
    // parameter val has range [0, 1]
    public static void SetHealthBarVal(float val)
    {
        try
        {
            HealthBarImage.fillAmount = val;
            if (HealthBarImage.fillAmount < 0.25f)
            {
                SetHealthBarColor(Color.red);
            }
            else if (HealthBarImage.fillAmount < 0.5f)
            {
                SetHealthBarColor(Color.yellow);
            }
            else
            {
                SetHealthBarColor(Color.green);
            }
        }
        catch {}
    }

    public static float GetHealthBarVal()
    {
        return HealthBarImage.fillAmount;
    }
    
    // set the color
    public static void SetHealthBarColor(Color barColor)
    {
        HealthBarImage.color = barColor;
    }

}