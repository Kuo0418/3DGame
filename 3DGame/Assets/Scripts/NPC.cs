using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間格")]
    public float interval = 0.2f;

    /// <summary>
    /// 玩家是否進入感應區
    /// </summary>
    public bool playerInAree;

    //定義列舉 eunm（下拉是選單-只能選一個）
    public enum NPCState
    {
        FirstDialog,Missioning,Finish
    }

    //列舉欄位
    //修飾詞 列舉名稱 自訂欄位名稱 指定 預設值；
    public NPCState start = NPCState.FirstDialog;

   /*
    private void Start()
    {
        //啟動協程
        StartCoroutine(Test());

    }

    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);
        print("嗨，我是一點五秒後");
        yield return new WaitForSeconds(2f);
        print("兩秒後");
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "機器人")
        {
            playerInAree = true;
            StartCoroutine(Dialog());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "機器人")
        {
            playerInAree = false;
            StopDialog();
        }
    }

    /// <summary>
    /// 停止對話
    /// </summary>
    private void StopDialog()
    {
        dialog.SetActive(false);  //關閉對話框
        StopAllCoroutines();      //停止所有協程
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    private IEnumerator Dialog()
    {
        /**
          //print(data.dailougA);       //取得字串全部資料
          //print(data.dailougA[0]);    //取得字串局部資料：語法 [編號]

          //for 迴圈：重複處理相同程式
          //for (int i = 0; i < 100; i++)
          //{
          //    print("迴圈：" + i);
          //}
          */

        //顯示對話框
        dialog.SetActive(true);
        //清空文字
        textContent.text = "";
        textName.text = name;


        //要說的話
        string dialogString = data.dailougB;

        switch (start)
        {
            case NPCState.FirstDialog:
               dialogString = data.dailougA;
                break;
            case NPCState.Missioning:
                dialogString = data.dailougB;
                break;
            case NPCState.Finish:
                dialogString = data.dailougC;
                break;
            default:
                break;
        }

        //字串的長度dialogA.Length
        for (int i = 0; i < dialogString.Length; i++)
        {
            //print(data.dailougA[i]);
            //文字串聯
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }

    }



}
