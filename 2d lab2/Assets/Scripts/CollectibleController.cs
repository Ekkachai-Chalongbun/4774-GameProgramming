using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] private SoCollectible collectibleObject;
    public CollectibleColor color;

    void Start()
    {
        if (TryGetComponent<CollectibleRandomize>(out CollectibleRandomize collectibleRandomize))
        {
            color = collectibleRandomize.color;
        }
    }

    CollectibleColor getColor()
    {
        return this.color;
    }

    void setColor(CollectibleColor color)
    {
        this.color = color;
    }
}
