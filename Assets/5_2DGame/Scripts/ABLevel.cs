using UnityEngine;


[CreateAssetMenu(fileName = "AB Level", menuName = "Scriptable Object/AB Level", order = int.MaxValue)]

public class ABLevel : ScriptableObject
{
   [SerializeField]

   private string levelName;

   public string LevelName { get { return levelName; } }

   [SerializeField]

   private int hp;

   public int Hp { get { return hp; } }

   [SerializeField]

   private int damage;

   public int Damage { get { return damage; } }

   [SerializeField]

   private float sightRange;

   public float SightRange { get { return sightRange; } }

   [SerializeField]

   private float moveSpeed;

   public float MoveSpeed { get { return moveSpeed; } }
}


