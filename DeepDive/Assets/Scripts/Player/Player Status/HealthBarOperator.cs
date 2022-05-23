using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOperator : MonoBehaviour
{
    private Image HealthBarImage;
    public SphereCast sphereCast;
    public Image healthbar;
    public int w_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = healthbar;

    }

    // sets the health bar value
    // parameter val has range [0, 1]
    public void SetHealthBarVal(float val)
    {
        if (w_count != 0)
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
        else
        {
            w_count = 1;
        }

    }

    public void SetCount(int new_count)
    {
        w_count = new_count;
    }

    public float GetHealthBarVal()
    {
        return HealthBarImage.fillAmount;
    }
    
    // set the color
    public void SetHealthBarColor(Color barColor)
    {
        HealthBarImage.color = barColor;
    }

}