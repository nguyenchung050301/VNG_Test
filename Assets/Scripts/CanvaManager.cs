using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvaManager : MonoBehaviour
{
    [SerializeField] private Vector2 offset;

    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;

    [SerializeField] private Transform player1HealthBar;
    [SerializeField] private Transform player2HealthBar;

    private Vector3 screenPos1;
    private Vector3 screenPos2;

    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
        player1HealthBar.gameObject.SetActive(false);
        player2HealthBar.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        player1HealthBar.gameObject.SetActive(true);
        player2HealthBar.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        screenPos1 = mainCamera.WorldToScreenPoint(player1Transform.position);
        player1HealthBar.transform.position = screenPos1 + (Vector3)offset;


        screenPos2 = mainCamera.WorldToScreenPoint(player2Transform.position);
        player2HealthBar.transform.position = screenPos2 + (Vector3)offset;
    }
}
