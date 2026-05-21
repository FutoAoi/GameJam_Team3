using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonAnimation : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler
{
    [Header("Scale")]
    [SerializeField] private RectTransform _target;
    [SerializeField] private float _hoverScale = 1.1f;
    [SerializeField] private float _duration = 0.15f;
    [SerializeField] private Ease _ease = Ease.OutBack;

    private Vector3 _defaultScale;
    private Tween _scaleTween;

    private void Awake()
    {
        if (_target == null)
        {
            _target = transform as RectTransform;
        }

        _defaultScale = _target.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverAnimation();
        AudioManager.Instance.PlaySe("ButtonMove");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetScale();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayClickAnimation();
        AudioManager.Instance.PlaySe("Button");
        OnClick();
    }

    /// <summary>
    /// ボタンを押した時の処理
    /// 継承して使う想定
    /// </summary>
    protected virtual void OnClick()
    {
        Debug.Log($"{gameObject.name} Clicked");
    }

    private void PlayHoverAnimation()
    {
        _scaleTween?.Kill();

        _scaleTween = _target
            .DOScale(_defaultScale * _hoverScale, _duration)
            .SetEase(_ease);
    }

    private void ResetScale()
    {
        _scaleTween?.Kill();

        _scaleTween = _target
            .DOScale(_defaultScale, _duration)
            .SetEase(Ease.OutQuad);
    }

    private void PlayClickAnimation()
    {
        _scaleTween?.Kill();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            _target.DOScale(_defaultScale * (_hoverScale * 0.9f), 0.05f)
        );

        sequence.Append(
            _target.DOScale(_defaultScale * _hoverScale, 0.08f)
        );

        sequence.SetEase(Ease.OutQuad);
    }
}