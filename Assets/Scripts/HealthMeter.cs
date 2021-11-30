using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    public void SetPersentage(float value)
    {
        int persentage = (int)(value * 100);
        gameObject.GetComponent<Text>().text = persentage.ToString();
    }
}
