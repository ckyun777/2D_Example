using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BallType
{
   Normal,
   Bomb,
}

public enum ABGameState
{
   Title,
   Menu,
   BeforeStart,
   //ReLoadPlayer,
   Start,
   ReStart,
   StageEnd,
}

public class ABGameSystem : MonoBehaviour
{
   public ABGameState m_State = ABGameState.Title;


   public int m_CurLevelNum = 1;
   public ABLevelData m_LevelData;
   public Text m_LevelText;
   public GameObject[] m_LevelPrefabs;
   public GameObject m_CurLevel;

   public GameObject[] m_LevelObjects;


   public float m_TimeCount = 0;
   public float m_TimeLimit = 10f;
   public Text m_TimeText;

   public AudioSource m_BGMSource;

   public Transform m_SlingshotPos;
   public int m_PlayerIdx = 0;
   public Projectile[]  m_Players;

   public GameObject m_Title;
   public GameObject m_Menu;
   
   private void Start()
	{
		switch (m_State)
		{
			case ABGameState.Title:
            Title();
            break;
			case ABGameState.Menu:
            Menu();
            break;
			case ABGameState.BeforeStart:
            BeforeStart();
				break;
			//case ABGameState.ReLoadPlayer:
			//	break;
			case ABGameState.Start:
				break;
			case ABGameState.ReStart:
				break;
			case ABGameState.StageEnd:
				break;
			default:
				break;
		}

	}

	public void Title()
	{
      m_State = ABGameState.Title;
      m_Title.SetActive(true);

	}

   public void Menu()
	{
      m_State = ABGameState.Menu;

      m_Title.SetActive(false);
      m_Menu.SetActive(true);
      m_TimeCount = 0f;
   }

    // Start is called before the first frame update
    public void BeforeStart()
    {
      m_Menu.SetActive(false);

		foreach (var item in m_LevelObjects)
		{
			item.SetActive(true);
		}

		m_CurLevel = Instantiate(m_LevelPrefabs[m_CurLevelNum - 1]);


      m_LevelText.text = m_LevelData.levels[m_CurLevelNum - 1].LevelName;

         m_BGMSource.clip = m_LevelData.levels[m_CurLevelNum - 1].LevelBGM;
         m_BGMSource.loop = true;
         m_BGMSource.Play();

         m_State = ABGameState.Start;
         Invoke("DelayAction", 2); //this will happen after 2 seconds
   }

   void DelayAction()
	{
      Block[] blocks = FindObjectsOfType<Block>();

		foreach (var item in blocks)
		{
         item.m_GameStarted = true;
		}

      //m_State = ABGameState.ReLoadPlayer;
      ResetBall();
	}

   void CreatePlayer()
	{
      if (m_Players != null)
      {
         if (m_Players.Length > m_PlayerIdx)
         {
            GameObject ball = Instantiate(m_Players[m_PlayerIdx].gameObject,
            new Vector3(-6.5f, -0.1f, 0), Quaternion.identity);

            ball.GetComponent<SpringJoint2D>().connectedBody = m_SlingshotPos.GetComponent<Rigidbody2D>();

            ball.GetComponent<Projectile>().m_DeactiveFunc += ResetBall;

            m_State = ABGameState.Start;

            m_PlayerIdx++;
         }
			else
			{
            m_State = ABGameState.StageEnd;
			}
      }
   }

   void ResetBall()
	{
      
      if (m_State == ABGameState.Start)
      {
         CreatePlayer();
         m_State = ABGameState.Start;
      }
   }

   public void StageEnd()
	{
      m_State = ABGameState.StageEnd;
      m_TimeText.text = "Stage Over";

      foreach (var item in m_LevelObjects)
      {
         item.SetActive(false);
      }

      Destroy( m_CurLevel );
      
      Menu();
   }

    // Update is called once per frame
    void Update()
    {
      if(m_State == ABGameState.Start)
		{
         m_TimeCount += Time.deltaTime;
         m_TimeText.text = m_TimeCount.ToString("000.00");

         if (m_TimeCount > m_TimeLimit)
			{
            StageEnd();
			}
		}
    }
}
