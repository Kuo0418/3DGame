using UnityEngine;
using UnityEngine.AI;  //引用 人工智慧API

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    public float CD = 2f;

    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;

    private void Awake()
    {
        //取的身上的元件<代理器>
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        //尋找其他遊戲物件("物件名稱").變形元件
        player = GameObject.Find("機器人").transform;

        //代理器 的 速度 與 停止距離
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        Track();
        Attack();
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (nav.remainingDistance<stopDistance)
        {
            //時間 累加（一幀的時間）
            timer += Time.deltaTime;

            //取得玩家的座標
            Vector3 pos = player.position;
            //將玩家的座標 Y 軸指定為 本物件的 Y 軸
            pos.y = transform.position.y;
            //看相(玩家的座標)
            transform.LookAt(pos);

            //如果 計時器 >= 冷卻時間 就攻擊 並且計時器歸零
            if (timer >= CD)
            {
                ani.SetTrigger("攻擊觸發");
                timer = 0;
            }
        }
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        //代理器.設定目的地(玩家的座標)
        nav.SetDestination(player.position);
        //動畫控制器.設定布林值("參數名稱"，剩餘距離>停止距離)
        ani.SetBool("跑步開關", nav.remainingDistance > stopDistance);
    }
}
