using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagName : MonoBehaviour
{
    [SerializeField]
    private new TagEnum tag;

    public TagEnum Tag => tag;
}
