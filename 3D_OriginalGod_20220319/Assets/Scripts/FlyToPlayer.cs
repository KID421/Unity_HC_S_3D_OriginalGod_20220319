using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���V���a
    /// </summary>
    public class FlyToPlayer : MonoBehaviour
    {
        [SerializeField, Header("���𭸦�ɶ�"), Range(0, 10)]
        private float delayToFly = 2.5f;
        [SerializeField, Header("����t��"), Range(0, 100)]
        private float speed = 10;
        [SerializeField, Header("�Z�����a�h�ִN�R���ç�s"), Range(0, 10)]
        private float distanceToDestory = 5;

        private Transform traPlayer;
        private string namePlayer = "�ǥͩf";
        private CoinManager coinManager;

        // float a = 0, b = 10;

        private void Awake()
        {
            Physics.IgnoreLayerCollision(3, 8);     // ���a �P ���� ���I��
            Physics.IgnoreLayerCollision(8, 8);     // ���� �P ���� ���I��

            traPlayer = GameObject.Find(namePlayer).transform;
            enabled = false;
            Invoke("DelayToFly", delayToFly);   // ���� 2.5 ��I�s DelayToFly

            coinManager = GameObject.Find("�����޲z��").GetComponent<CoinManager>();
        }

        private void Update()
        {
            // �m�ߴ���
            // a = Mathf.Lerp(a, b, 0.5f);
            // print("A �ȡG" + a);

            Fly();
        }

        /// <summary>
        /// �����ƫ�A����
        /// </summary>
        private void DelayToFly()
        {
            enabled = true;
        }

        /// <summary>
        /// ����
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
        /// �ˬd�Z���çR������
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

