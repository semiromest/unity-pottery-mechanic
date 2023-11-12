using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colls : MonoBehaviour
{
    public int index;
    BoxCollider boxCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        index = transform.GetSiblingIndex();
    }

    public void HitCollider(float damage)
    {
        if (boxCollider.size.y - damage > 0.14)
        {
            boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y - damage, boxCollider.size.z);
        }
        else
        {
            Destroy(this);
        }
    }
}
