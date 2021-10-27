using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    public static UIElements _instance;

    public Text HealthTextUI;
    public Text SelectedWeaponTextUi;
    public Text WaveTextUI;
    public void setHealth(int health)
    {
        HealthTextUI.text = "Health " + health;
    }
    public void setWaveText(int wave)
    {
        WaveTextUI.text = "Wave " + wave;
    }


    public void updateSelectedAttack(Attack attack)
    {
        SelectedWeaponTextUi.text = attack.attackName + "\r\nlvl: " + attack.level;
    }
    // Start is called before the first frame update
    public static UIElements Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIElements>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
