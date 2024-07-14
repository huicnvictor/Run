using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyManager : MonoBehaviour
{
    private TMP_Dropdown tmpDropdown; // 使用 TMP_Dropdown 类型

    void Start()
    {
        // 查找 Canvas 下的 ModeMenu 对象
        GameObject modeMenuObject = GameObject.Find("ModeMenu");

        if (modeMenuObject != null && !modeMenuObject.activeSelf)
        {
            modeMenuObject.SetActive(true); // 如果 ModeMenu 不可见，暂时激活它
        }

        // 获取 ModeMenu 对象下的 TMP_Dropdown 组件
        tmpDropdown = modeMenuObject.GetComponentInChildren<TMP_Dropdown>();

        if (tmpDropdown != null)
        {
            tmpDropdown.onValueChanged.AddListener(delegate {
                DifficultyChanged(tmpDropdown);
            });

            // 初始化时调用一次，以设置初始难度
            DifficultyChanged(tmpDropdown);
        }
        else
        {
            Debug.LogError("TMP_Dropdown component not found under ModeMenu! Check your hierarchy.");
        }

        if (modeMenuObject != null && !modeMenuObject.activeSelf)
        {
            modeMenuObject.SetActive(false); // 恢复 ModeMenu 的可见性状态
        }
    }
    void DifficultyChanged(TMP_Dropdown dropdown)
    {
        switch (dropdown.value) {
            case 0://EASY
                GameSettings.PlayerAcceleration = 0.00f;
                GameSettings.multiplier = 10;
                break;
                case 1: //NORMAL
                GameSettings.PlayerAcceleration = 0.03f;
                GameSettings.multiplier = 15;
                break;
                case 2: //HARD
                GameSettings.PlayerAcceleration = 0.1f;
                GameSettings.multiplier = 20;
                break;
                default:
                GameSettings.PlayerAcceleration = 0.00f;
                GameSettings.multiplier = 10;
                break;
        }
        Debug.Log(GameSettings.PlayerAcceleration);
    }
}
