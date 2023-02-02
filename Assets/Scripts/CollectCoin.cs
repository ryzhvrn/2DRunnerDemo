using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _coinCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(collision.gameObject);
            _coinCount++;
            _text.text = _coinCount.ToString();
        }
    }
}
