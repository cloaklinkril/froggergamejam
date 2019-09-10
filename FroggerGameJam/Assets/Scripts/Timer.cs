using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float Timeset;
    public float TimeNum;
    public UnityEvent TimerEnd;
    RectTransform rectTransform;
    float StartWidth;
    // Start is called before the first frame update
    void Start()
    {
        TimeNum = Timeset;
        rectTransform = GetComponent<RectTransform>();
        StartWidth = rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeNum <= 0)
        {
            //Destroy(GameObject.FindGameObjectWithTag("Player"));
            ResetTimer();
            TimerEnd.Invoke();
        }
        TimeNum -= Time.deltaTime;
        //gameObject.transform.localScale = new Vector2(5, 1);
        var TimeFraction = TimeNum / Timeset;
        var NewWidth = StartWidth * TimeFraction;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, NewWidth);
    }

    public void ResetTimer()
    {
        TimeNum = Timeset;
    }
}
