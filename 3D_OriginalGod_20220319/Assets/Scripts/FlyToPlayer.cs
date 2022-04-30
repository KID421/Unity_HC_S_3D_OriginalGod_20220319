using UnityEngine;

namespace KID
{
    /// <summary>
    /// 飛向玩家
    /// </summary>
    public class FlyToPlayer : MonoBehaviour
    {
        [SerializeField, Header("延遲飛行時間"), Range(0, 10)]
        private float delayToFly = 2.5f;
        [SerializeField, Header("飛行速度"), Range(0, 100)]
        private float speed = 10;
        [SerializeField, Header("距離玩家多少就刪除並更新"), Range(0, 10)]
        private float distanceToDestory = 5;

        private Transform traPlayer;
        private string namePlayer = "學生妹";
        private CoinManager coinManager;

        // float a = 0, b = 10;

        private void Awake()
        {
            Physics.IgnoreLayerCollision(3, 8);     // 玩家 與 金幣 不碰撞
            Physics.IgnoreLayerCollision(8, 8);     // 金幣 與 金幣 不碰撞

            traPlayer = GameObject.Find(namePlayer).transform;
            enabled = false;
            Invoke("DelayToFly", delayToFly);   // 延遲 2.5 秒呼叫 DelayToFly

            coinManager = GameObject.Find("金幣管理器").GetComponent<CoinManager>();
        }

        private void Update()
        {
            // 練習插值
            // a = Mathf.Lerp(a, b, 0.5f);
            // print("A 值：" + a);

            Fly();
        }

        /// <summary>
        /// 延遲秒數後再飛行
        /// </summary>
        private void DelayToFly()
        {
            enabled = true;
        }

        /// <summary>
        /// 飛行
        /// </summary>
        private void Fly()
        {
            Vector3 posCoin = transform.position;
            Vector3 posPlayer = traPlayer.position;

            posCoin = Vector3.Lerp(posCoin, posPlayer, speed * Time.deltaTime);

            transform.position = posCoin;

            CheckDistanceAndDestroy();
        }

        /// <summary>
        /// 檢查距離並刪除金幣
        /// </summary>
        private void CheckDistanceAndDestroy()
        {
            float dis = Vector3.Distance(transform.position, traPlayer.position);

            if (dis <= distanceToDestory)
            {
                coinManager.AddCoin();
                Destroy(gameObject);
            }
        }
    }
}

