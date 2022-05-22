using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOperator : MonoBehaviour
{
    private static Image HealthBarImage;
    public SphereCast sphereCast;
    public Image healthbar;
    private static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = healthbar;

    }

    // sets the health bar value
    // parameter val has range [0, 1]
    public static void SetHealthBarVal(float val)
    {
        if (count != 0) {
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
        else {
            count = 1;
        }
        
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