using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardController : MonoBehaviour
{
    private MenuUI _menuUI;
    private Card _firstCard, _secondCard;

    public bool CanOpen
    {
        get { return _secondCard == null; }
    }

    [Inject]
    private void Construct(MenuUI service) => _menuUI = service;

    public void ImageOpened(Card startObject)
    {
        if(_firstCard == null)
            _firstCard = startObject;
        else
        {
            _secondCard = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (_firstCard.SpriteId == _secondCard.SpriteId)
            _menuUI.IncreaseScore();
        else
        {
            yield return new WaitForSeconds(1.5f);

            _firstCard.Close();
            _secondCard.Close();
        }

        _menuUI.IncreaseAttempts();

        _firstCard = null;
        _secondCard = null;
    }
}
