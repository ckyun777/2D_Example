using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaMobSearch : MonoBehaviour
{
   private List<GameObject> ObjectsInRange = new List<GameObject>();

	public void Start()
	{
		Destroy(gameObject, 0.3f);
	}

	public void OnTriggerEnter2D(Collider2D col)
   {
      ObjectsInRange.Add(col.gameObject);

		foreach (var item in ObjectsInRange)
		{
         Rigidbody2D _other = item.GetComponent<Rigidbody2D>();

         //
         if(_other != null)
			{
            print(_other.name);
            //_other.AddExplosionForce(10f, this.transform.position, 2);
            _other.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
         }
         
      }
   }
}

