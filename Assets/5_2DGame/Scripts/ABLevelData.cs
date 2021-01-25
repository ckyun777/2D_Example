using UnityEngine;


[CreateAssetMenu(fileName = "AB Level Data", menuName = "Scriptable Object/AB Level Data", order = int.MaxValue)]

public class ABLevelData : ScriptableObject

{
   [SerializeField]
   public ABLevel[] levels;

}
