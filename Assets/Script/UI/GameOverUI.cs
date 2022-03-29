using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        transform.Find("ReStart").GetComponent<Button>()
            .onClick.AddListener(() =>
                {
                    this.gameObject.SetActive(false);

                    // 触发事件
                    GameReStart.Trigger();
                });

        transform.Find("ReStart _AI").GetComponent<Button>()
            .onClick.AddListener(() =>
                {
                    this.gameObject.SetActive(false);

                    // 触发事件
                    GameReStartAI.Trigger();
                });

        transform.Find("Quit").GetComponent<Button>()
            .onClick.AddListener(() =>
                {
                    // 触发事件
                    GameQuit.Trigger();
                });
    }

    private void OnEnable()
    {
        var message = transform.Find("Message").GetComponent<Text>();
        switch (FindObjectOfType<ChessBooard>().Outcome())
        {
            case 1:
                //红方获胜
                message.color = Color.red;
                message.text = "红方获胜!";
                break;
            case 2:
                //黄方获胜
                message.color = Color.yellow;
                message.text = "黄方获胜!";
                break;
            case 3:
                //平局
                message.color = Color.blue;
                message.text = "平局!";
                break;
            default:
                Debug.Log("出错");
                break;
        }
    }
}
