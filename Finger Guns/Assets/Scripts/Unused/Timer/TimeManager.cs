﻿using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float slowdownFactor = 0.05f;
    [SerializeField] float slowdownLength = 2f;

    private void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.deltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, .01f, 1f);
    }
    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
