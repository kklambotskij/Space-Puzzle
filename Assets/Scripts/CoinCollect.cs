using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] public Transform target;

    private float startSpeed;
    public void StartCoinMove(int count, Action onComplete, Action onLastCoinEnd)
    {
        StartCoinMove(transform, count, onComplete, onLastCoinEnd);
    }

    public void StartCoinMove(Transform initial, int count, Action onComplete, Action onLastCoinEnd)
    {
        for (int i = 0; i < count; i++)
        {
            var coin = Instantiate(CoinPrefab, initial);
            var x = UnityEngine.Random.Range(-100, 100);
            var y = UnityEngine.Random.Range(-100, 100);
            var s = startSpeed + UnityEngine.Random.Range(15, 30);
            if (i == count - 1)
            {
                onComplete += onLastCoinEnd;
            }
            StartCoroutine(MoveCoin(coin.transform, s/10, initial.position + new Vector3(x, y, 0), target.position, onComplete));
        }
    }

    IEnumerator MoveCoin(Transform obj, float speed, Vector3 startPos, Vector3 endPos, Action onComplete)
    {
        float time = 0;
        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, endPos, time);
            yield return new WaitForEndOfFrame();
        }
        Destroy(obj.gameObject, 1);
        obj.GetComponent<AudioSource>().Play();
        onComplete.Invoke();
    }    
}
