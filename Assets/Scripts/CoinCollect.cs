using System;
using System.Collections;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] public Transform target;
    [SerializeField] float range = 400;
    public void StartCoinMove(int count, Action onComplete, Action onLastCoinEnd)
    {
        StartCoinMove(transform, count, onComplete, onLastCoinEnd);
    }

    public void StartCoinMove(Transform initial, int count, Action onComplete, Action onLastCoinEnd)
    {
        for (int i = 0; i < count; i++)
        {
            float x = UnityEngine.Random.Range(-range, range);
            float y = UnityEngine.Random.Range(-range, range);
            float speed = UnityEngine.Random.Range(15, 20);
            var position = initial.position + new Vector3(x, y, 0);
            var coin = Instantiate(CoinPrefab, initial);
            if (i == count - 1)
            {
                onComplete += onLastCoinEnd;
            }
            StartCoroutine(MoveCoin(coin.transform, speed / 10, position, target.position, onComplete));
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
