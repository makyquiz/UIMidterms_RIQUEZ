using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimationManager : MonoBehaviour
{
    public RectTransform leaf;
    public Button scaleButton, zoomButton, pulseButton, bounceButton, shakeButton, slideRightButton;

    private Vector2 originalPosition;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = leaf.localScale;
        originalPosition = leaf.anchoredPosition;

        scaleButton.onClick.AddListener(() =>
        {
            leaf.DOScale(Vector3.one * 0.01f, 0.5f).SetEase(Ease.InOutQuad)
            .OnComplete(() => leaf.DOScale(originalScale, 0.5f).SetEase(Ease.InOutQuad));
        });

        zoomButton.onClick.AddListener(() =>
        {
            leaf.DOScale(Vector3.one * 0.01f, 0.2f).SetEase(Ease.InOutExpo)
            .OnComplete(() => leaf.DOScale(originalScale, 0.5f).SetEase(Ease.InOutQuad));
        });

        pulseButton.onClick.AddListener(() =>
        {
            leaf.DOScale(originalScale * 1.2f, 0.3f)
            .SetEase(Ease.InOutSine)
            .OnComplete(() => leaf.DOScale(originalScale, 0.3f).SetEase(Ease.InOutSine));
        });

        bounceButton.onClick.AddListener(() =>
        {
            leaf.DOAnchorPosY(originalPosition.y + 50f, 0.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => leaf.DOAnchorPosY(originalPosition.y, 0.5f).SetEase(Ease.OutQuad));
        });

        shakeButton.onClick.AddListener(() =>
        {
            leaf.DOShakePosition(0.5f, new Vector2(20f, 20f));
        });

        slideRightButton.onClick.AddListener(() =>
        {
            leaf.DOAnchorPos(originalPosition + new Vector2(200f, 0f), 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => leaf.DOAnchorPos(originalPosition, 0.5f).SetEase(Ease.OutQuad));
        });
    }
}