using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject leftWallPrefab;
    public GameObject rightWallPrefab;
    public GameObject bottomWallPrefab;
    public GameObject backgroundPrefab; // Додаємо префаб для фону


    void Start()
    {
        // Розміри екрану в пікселях
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Отримання зіставлення екрану з глобальними координатами у грі
        Vector3 leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, screenHeight / 2, 10));
        Vector3 rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight / 2, 10));
        Vector3 topEdge = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth / 2, screenHeight, 10));
        Vector3 bottomEdge = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth / 2, 0, 10));

        // Розміщення стінок на краях екрану
        GameObject leftWall = Instantiate(leftWallPrefab, new Vector3(leftEdge.x - 0.5f, 0, 0), Quaternion.identity);

        // Розміщення та розвертання правої стінки на краї екрану
        GameObject rightWall = Instantiate(rightWallPrefab, new Vector3(rightEdge.x + 0.5f, 0, 0), Quaternion.identity);
        GameObject bottomWall = Instantiate(bottomWallPrefab, new Vector3(0, bottomEdge.y, 0), Quaternion.identity);
        bottomWall.transform.rotation = Quaternion.Euler(0, 0,0);


        
    }
}
