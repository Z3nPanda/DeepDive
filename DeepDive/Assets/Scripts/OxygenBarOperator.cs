using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarOperator : MonoBehaviour
{
    private static Image OxygenBarImage;

    // sets the oxygen bar value
    // parameter val has range [0, 1]
    public static void SetOxygenBarVal(float val)
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

    public static float GetOxygenBarVal()
    {
        return OxygenBarImage.fillAmount;
    }

    // set the color
    public static void SetOxygenBarColor(Color barColor)
    {
        OxygenBarImage.color = barColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        OxygenBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
