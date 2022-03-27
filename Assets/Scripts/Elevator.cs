using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private Light _light;
    [SerializeField] private BoxCollider2D _myCollider;
    private bool _isOpen = false;
    void Start()
    {
        _isOpen = false;
        _levelManager = FindObjectOfType<LevelManager>();
        _myCollider = GetComponent<BoxCollider2D>();
        _light.color = new Color(255,0,0);
    }
    void Update()
    {
        if (_levelManager.isLevelEnd)
        {
            _isOpen = true;
            _light.color = new Color(5,29,0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isOpen)
        {
            if(collision.gameObject.tag == "Player")
            {
                SceneLoader.LoadNextScene();
            }
        }
    }
}
