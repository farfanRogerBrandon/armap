using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName ="ITEM_SO", menuName ="ScriptableObject/Item")]
public class Item_SO : ScriptableObject
{
    public string title;
    [TextArea]
    public string description;

    public List<VideoClip> vcClips;

    public GameObject gmCharacter;

}
