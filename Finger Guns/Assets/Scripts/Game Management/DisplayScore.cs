﻿using UnityEngine;
using TMPro;

namespace Scripts
{
    public class DisplayScore : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private GameSession gameSession;

        // Start is called before the first frame update
        void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            gameSession = FindObjectOfType<GameSession>();
        }

        // Update is called once per frame
        void Update()
        {
            //scoreText.text = "Score: " + gameSession.GetScore().ToString();
        }
    }
}
