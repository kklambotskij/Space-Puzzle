using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    [SerializeField] RawImage background;
    [SerializeField] float speed;

    float posY;    

    void Update()
    {
        posY += speed * Time.deltaTime;
        background.uvRect = new Rect(0, posY, background.uvRect.height, background.uvRect.height);
    }
}
