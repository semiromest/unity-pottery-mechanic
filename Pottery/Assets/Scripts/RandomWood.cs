using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWood : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SkinnedMeshRenderer modelWood;
    [SerializeField] private SkinnedMeshRenderer Wood;
    void Start()
    {
        Mesh mesh = modelWood.sharedMesh;
        int blendShapeCount = mesh.blendShapeCount;
        for (int i = 0; i < blendShapeCount; i+=Random.Range(0,7))
        {
            modelWood.SetBlendShapeWeight(i, Random.Range(0, 100));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
