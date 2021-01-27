﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABGameSystem : MonoBehaviour
{
   public int m_CurrentLevel = 1;

   public ABLevelData m_LevelData;

   public Text m_LevelText;

   public AudioSource m_BGMSource;

    // Start is called before the first frame update
    void Start()
    {
        m_LevelText.text = m_LevelData.levels[m_CurrentLevel - 1].LevelName;

         m_BGMSource.clip = m_LevelData.levels[m_CurrentLevel - 1].LevelBGM;
         m_BGMSource.loop = true;
         m_BGMSource.Play();

         Invoke("DelayAction", 2); //this will happen after 2 seconds
   }

   void DelayAction()
	{
      Block[] blocks = FindObjectsOfType<Block>();

		foreach (var item in blocks)
		{
         item.m_GameStarted = true;
		}
	}


    // Update is called once per frame
    void Update()
    {
        
    }
}
