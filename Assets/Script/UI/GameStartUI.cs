using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUI : MonoBehaviour
{
    void Start()
    {
        transform.Find("Start").GetComponent<Button>()
            .onClick.AddListener(() =>
                {
                    this.gameObject.SetActive(false);

                    // 触发事件
                    GameStart.Trigger();
                });

        transform.Find("Start_AI").GetComponent<Button>()
            .onClick.AddListener(() =>
                {
                    this.gameObject.SetActive(false);

                    // 触发事件
                    GameStartAI.Trigger();
                });

        transform.Find("Quit").GetComponent<Button>()
            .onClick.AddListener(() =>
                {
                    // 触发事件
                    GameQuit.Trigger();
                });
    }
}
