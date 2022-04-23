using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ĤH���
    /// 1. ��q
    /// 2. ����
    /// 3. ���ʳt��
    /// 4. �l�ܽd��
    /// 5. �����d��
    /// 6. �g���
    /// 7. ��������
    /// 8. �������ƶq
    /// 9. ���������v
    /// </summary>
    // Create Asset Menu �إ߸�ƿﶵ
    // menuName �ﶵ�W�١A�i�H�ϥ� / �إߤl�ﶵ�]��ĳ�^��^
    // fileName �ɮצW�١]��ĳ�^��^
    [CreateAssetMenu(menuName = "KID/Data Enemy", fileName = "Data Enemy")]
    // Scriptable Object �}���ƪ���G�N��ƥH����覡�x�s�� Project ��
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 1000)]
        public float hp;
        [Header("����"), Range(0, 100)]
        public float attack;
        [Header("���ʳt��"), Range(0, 50)]
        public float speed;
        [Header("�l�ܽd��"), Range(7, 50)]
        public float rangeTrack;
        [Header("�����d��"), Range(0, 7)]
        public float rangeAttack;
        [Header("�g���"), Range(0, 1000)]
        public float exp;
        [Header("��������")]
        public GameObject goCoin;
        [Header("�����ƶq"), Range(0, 500)]
        public int coinCount;
        [Header("�����������v"), Range(0, 1)]
        public float coinProbability;
    }
}

