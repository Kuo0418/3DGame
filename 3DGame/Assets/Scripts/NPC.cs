using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    /// <summary>
    /// 玩家是否進入感應區
    /// </summary>
    public bool playerInAree;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "機器人")
        {
            playerInAree = true;
            Dialog();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "機器人")
        {
            playerInAree = false;
        }
    }

    private void Dialog()
    {
        //print(data.dailougA);       //取得字串全部資料
        //print(data.dailougA[0]);    //取得字串局部資料：語法 [編號]

        //for 迴圈：重複處理相同程式
        //for (int i = 0; i < 100; i++)
        //{
        //    print("迴圈：" + i);
        //}

        //字串的長度dialogA.Length
        for (int i = 0; i < data.dailougA.Length; i++)
        {
            print(data.dailougA[i]); 
        }

    }



}
