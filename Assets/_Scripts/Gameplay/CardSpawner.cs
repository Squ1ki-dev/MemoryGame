using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CardSpawner : MonoBehaviour
{
    private Card _card;
    private List<Card> _spawnedCards = new List<Card>();
    [SerializeField] private FieldConfig _fieldConfig;

    [Inject] private DiContainer diContainer;

    [Inject]
    public void Construct(Card card)
    {
        _card = card;
    }

    public void ShuffleField()
    {
        ClearField();

        int[] locations = LocationGenerator.Generate(_fieldConfig.NumPairs);
        locations = Randomiser.Shuffle(locations);

        Vector3 startPosition = _card.transform.position;

        PopulateField(startPosition, locations);
    }

    private void ClearField()
    {
        foreach (Card card in _spawnedCards)
        {
            Destroy(card.gameObject);
        }
        _spawnedCards.Clear();
    }

    private void PopulateField(Vector3 startPosition, int[] locations)
    {
        for (int i = 0; i < _fieldConfig.Columns; i++)
        {
            for (int j = 0; j < _fieldConfig.Rows; j++)
            {
                Card gameImage = InstantiateImage();
                _spawnedCards.Add(gameImage);

                int index = j * _fieldConfig.Columns + i;
                int id = locations[index];

                gameImage.ChangeSprite(id, _fieldConfig.images[id]);
                PositionImage(gameImage, startPosition, i, j);
            }
        }
    }

    private void PositionImage(Card gameImage, Vector3 startPosition, int i, int j)
    {
        float positionX = (_fieldConfig.Xspace * i) + startPosition.x;
        float positionY = (_fieldConfig.Yspace * j) + startPosition.y;
        gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
    }

    private Card InstantiateImage() => diContainer.InstantiatePrefabForComponent<Card>(_card);
}