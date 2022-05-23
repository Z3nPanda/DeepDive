using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarOperator : MonoBehaviour
{
    private Image OxygenBarImage;
    int w_count = 0;

    // sets the oxygen bar value
    // parameter val has range [0, 1]
    public void SetOxygenBarVal(float val)
    {
        if (w_count != 0)
        {
            OxygenBarImage.fillAmount = val;
            if (OxygenBarImage.fillAmount < 0.25f)
            {
                SetOxygenBarColor(Color.red);
            }
            else if (OxygenBarImage.fillAmount < 0.5f)
            {
                SetOxygenBarColor(Color.yellow);
            }
            else
            {
                SetOxygenBarColor(Color.white);
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

    public float GetOxygenBarVal()
    {
        return OxygenBarImage.fillAmount;
    }

    // set the color
    public void SetOxygenBarColor(Color barColor)
    {
        OxygenBarImage.color = barColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        OxygenBarImage = GetComponent<Image>();
    }
}
