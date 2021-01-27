using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
   Normal,
   Bomb,

}

public class Projectile : MonoBehaviour
{
   public BallType m_Type = BallType.Normal;
   public int m_TouchCount = 0;
   public GameObject m_SearchArea;
   public GameObject m_BombEffect;


   Rigidbody2D rb;
   SpringJoint2D springJoint;
   bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      springJoint = GetComponent<SpringJoint2D>();

    }

    // Update is called once per frame
    void Update()
    {
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
                  //
                  print("Bomb");
                  Instantiate(m_SearchArea, transform.position, Quaternion.identity); 
                  Instantiate(m_BombEffect, transform.position, Quaternion.identity);
                  Destroy(gameObject);
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

         StartCoroutine(Release());
      }
      
   }

   IEnumerator Release()
	{
      yield return new WaitForSeconds(0.15f);

      GetComponent<SpringJoint2D>().enabled = false;
	}
}
