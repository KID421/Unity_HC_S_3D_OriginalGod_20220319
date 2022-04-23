using UnityEngine;
using UnityEngine.AI;

namespace KID
{
    /// <summary>
    /// �ĤH�G�򥻦欰
    /// �l�ܡB�����B���˻P���`
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Header("�Ǫ����")]
        private DataEnemy data;
        [SerializeField, Header("���a����W��")]
        private string namePlayer = "�ǥͩf";
        [SerializeField, Header("�l�ܥؼйϼh")]
        private LayerMask layerTrack;

        private Animator ani;
        private NavMeshAgent nav;
        private Transform traPlayer;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeAttack);
        }

        private void Update()
        {
            CheckPlayerInTrackRange();
        }

        /// <summary>
        /// �ˬd���a�O�_�b�l�ܽd��
        /// </summary>
        private void CheckPlayerInTrackRange()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, data.rangeTrack, layerTrack);
            print(hits[0].name);
        }
    }
}

