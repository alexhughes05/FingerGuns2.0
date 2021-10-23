using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AfkChecker : MonoBehaviour
{
    [SerializeField]
    private FgmInputReader fgmInput;
    [SerializeField] 
    private float timeUntilAfk;
    private Vector2 oldMouseInput;
    private float afkCounter;

    public bool IsAfk { get; private set; }

    private void OnEnable()
    {
        fgmInput.AimEvent += AimPosChanged;
    }

    private void OnDisable()
    {
        fgmInput.AimEvent -= AimPosChanged;
    }

    private void Start()
    {
        afkCounter = timeUntilAfk;
    }

    private void AimPosChanged(Vector2 currentMousePos)
    {
        if (currentMousePos != oldMouseInput)
        {
            IsAfk = false;
            afkCounter = timeUntilAfk;
            oldMouseInput = currentMousePos;
        }
    }

    private void Update()
    {
        if (Keyboard.current.anyKey.isPressed)
        {
            afkCounter = timeUntilAfk;
            IsAfk = false;
        }
        afkCounter -= Time.deltaTime;
        if (afkCounter <= 0)
            IsAfk = true;
    }
}
