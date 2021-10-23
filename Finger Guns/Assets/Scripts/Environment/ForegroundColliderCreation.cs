﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundColliderCreation : MonoBehaviour
{
    #region Variables
    
    //public
    [SerializeField] float padding = -0.1f;

    //private
    private float targetWidth;
    private float targetHeight;

    // Components
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    #endregion

    private void Awake()
    {
        if (GetComponent<SpriteRenderer>() == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (GetComponent<BoxCollider2D>() == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        // Set variables to be used in manipulating the BoxCollider2D
        targetWidth = spriteRenderer.size.x;
        targetHeight = spriteRenderer.size.y;
        targetWidth += padding;
        targetHeight += padding;

        // Set BoxCollider2D values to match the SpriteRenderer
        boxCollider.size = new Vector2(targetWidth, targetHeight);
    }
}
