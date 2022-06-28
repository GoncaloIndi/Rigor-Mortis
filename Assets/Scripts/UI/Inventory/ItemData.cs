using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    public int Id;
    public string Name;
    [TextArea(15, 20)]
    public string ExamineText;
    public Sprite Icon;

}
