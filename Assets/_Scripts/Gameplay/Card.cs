using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    private CardController _cardController;
    private int _spriteId;
    public int SpriteId
    {
        get { return _spriteId; }
    }

    [Inject]
    private void Construct(CardController cardController) => _cardController = cardController;

    private void Start() => RotateCard(180f, 1f);

    public void OnMouseDown()
    {
        if (_cardController.CanOpen)
        {
            RotateCard(0f, 1f);
            _cardController.ImageOpened(this);
        }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void RotateCard(float targetAngle, float duration)
    {
        transform.DOKill();

        transform
            .DORotate(new Vector3(0f, targetAngle, 0f), duration)
            .SetEase(Ease.InOutSine);
    }

    public void Close() => RotateCard(180f, 1f);
}