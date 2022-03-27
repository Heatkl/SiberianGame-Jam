using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Text _redText;
    [SerializeField] Text _greenText;
    [SerializeField] Text _blueText;
    [SerializeField] Image _darkScreen;

    public bool isLevelEnd = false;
    public int _redEnemies = 0;
    public int _greenEnemies = 0;
    public int _blueEnemies = 0;

    private void Start()
    {
        isLevelEnd = false;
        _blueText.text = $"{_blueEnemies}";
        _greenText.text = $"{_greenEnemies}";
        _redText.text = $"{_redEnemies}";
    }
    private void Update()
    {
        if(_redEnemies <= 0 && _greenEnemies <=0 && _blueEnemies <= 0)
        {
            isLevelEnd = true;
        }
    }
    public int RedEnemies
    {
        get
        {
            return _redEnemies;
        }
        set
        {
            _redEnemies = value;
            if (_redEnemies >= 0)
                _redText.text = $"{_redEnemies}";
        }
    }
    public int GreenEnemies
    {
        get
        {
            return _greenEnemies;
        }
        set
        {
            _greenEnemies = value;
            if (_greenEnemies >= 0)
                _greenText.text = $"{_greenEnemies}";
        }
    }
    public int BlueEnemies
    {
        get
        {
            return _blueEnemies;
        }
        set
        {
            _blueEnemies = value;
            if (_blueEnemies >= 0)
                _blueText.text = $"{_blueEnemies}";
        }
    }
    public void Lose()
    {
        _darkScreen.GetComponent<Animator>().SetTrigger("loadLose");
    }
}
