using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
   public BallType m_Type = BallType.Normal;
   public int m_TouchCount = 0;
   public GameObject m_SearchArea;
   public GameObject m_BombEffect;

   Rigidbody2D rb;
   SpringJoint2D springJoint;
   bool isPressed = false;

   public delegate void DeactiveFunc();
   public event DeactiveFunc m_DeactiveFunc;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      springJoint = GetComponent<SpringJoint2D>();

    }

   public void Shoot()
	{
      
		switch (m_Type)
		{
			case BallType.Normal:
            Invoke("DeActiveBall", 5f);
            break;
			case BallType.Bomb:
            Invoke("BombAction", 6f);
            break;
			default:
				break;
		}

	}

   void BombAction()
	{
      print("Bomb");
      Instantiate(m_SearchArea, transform.position, Quaternion.identity);
      Instantiate(m_BombEffect, transform.position, Quaternion.identity);

      DeActiveBall();

      Destroy(gameObject);
   }

   void DeActiveBall()
	{
      print("DeActive");
      m_DeactiveFunc();

		foreach (var item in m_DeactiveFunc.GetInvocationList())
		{
         m_DeactiveFunc -= (DeactiveFunc)item;
		}
      this.enabled = false;


	}

    // Update is called once per frame
    void Update()
    {
      if(this.enabled == false) return;

      if(isPressed)
		{
         rb.position = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		}

      if(m_TouchCount == 1)
		{
         if(Input.GetMouseButtonDown(0))
			{
            switch (m_Type)
            {
               case BallType.Normal:

                  break;
               case BallType.Bomb:
                  BombAction();
                  break;

               default:
                  break;
            }
         }
		}
    }

	private void OnMouseDown()
	{
      if (m_TouchCount == 0)
		{
         isPressed = true;
         rb.isKinematic = true;
      }
      
	   
	}

	private void OnMouseUp()
	{
      if (m_TouchCount == 0)
      {
         m_TouchCount++;

         isPressed = false;
         rb.isKinematic = false;

         Shoot();
         StartCoroutine(Release());
      }
      
   }

   IEnumerator Release()
	{
      yield return new WaitForSeconds(0.15f);

      GetComponent<SpringJoint2D>().enabled = false;
	}
}
