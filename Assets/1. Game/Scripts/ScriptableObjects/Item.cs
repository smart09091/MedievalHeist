using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] 
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int graphicIndex;
    public int score;
    public bool isDefaultItem = false;
}
