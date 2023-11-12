using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Wood : MonoBehaviour
{
    [SerializeField] private Transform woodTransform;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float rotationDuration;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        woodTransform.DOLocalRotate(rotationVector, rotationDuration,RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
    }

    public void Hit(int keyIndex,float damage)
    {
        float colliderHeight = 1.4f;
        float newWeight = skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) + damage * (100/ colliderHeight);
        skinnedMeshRenderer.SetBlendShapeWeight(keyIndex, newWeight);
    }
}
