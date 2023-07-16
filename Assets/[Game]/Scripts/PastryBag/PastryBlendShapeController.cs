using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastryBlendShapeController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer pastryMesh;

    [Header("Settings")]
    [SerializeField] private float blendSpeed = 5f;
    [SerializeField] private Ease blendEase = Ease.InOutBounce;

    private Tween _blendTween;

    private const int BLENDSHAPE_INDEX = 0;
    private const int BLENDSHAPE_MAX_WEIGHT = 111;
    private const int BLENDSHAPE_MIN_WEIGHT = 0;

    public void Squeeze()
    {
        UpdateBlendShape(BLENDSHAPE_MAX_WEIGHT);
    }

    public void Release()
    {
        UpdateBlendShape(BLENDSHAPE_MIN_WEIGHT);
    }

    private void UpdateBlendShape(float to)
    {
        float current = pastryMesh.GetBlendShapeWeight(BLENDSHAPE_INDEX);
        _blendTween?.Kill();
        _blendTween = DOTween.To(() => current, x => current = x, to, blendSpeed).SetSpeedBased().SetEase(blendEase)
            .OnUpdate(() => {
                pastryMesh.SetBlendShapeWeight(BLENDSHAPE_INDEX, current);
            });
    }
}