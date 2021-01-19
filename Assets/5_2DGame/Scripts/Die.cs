using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
   public GameObject Bird;
   public GameObject Pattern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Ground")
		{
         Destroy(Bird);
         Instantiate(Pattern, transform.position, Quaternion.identity);
		}
	}
}
