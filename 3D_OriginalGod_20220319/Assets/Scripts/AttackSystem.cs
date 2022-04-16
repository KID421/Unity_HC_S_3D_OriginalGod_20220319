using UnityEngine;

/// <summary>
/// KID �R�W�Ŷ�
/// </summary>
namespace KID
{
    /// <summary>
    /// �����t��
    /// 1. �Z������
    /// 2. �����ʵe
    /// 3. �M���S��
    /// 4. �����P�w
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        #region ���
        private Animator ani;

        // SerializeField �ǦC�����G�N�p�H�����ܩ��ݩʭ��O

        [SerializeField, Header("�Z�� �I��")]
        private GameObject goWeaponBack;
        [SerializeField, Header("�Z�� ��W")]
        private GameObject goWeaponHand;
        [SerializeField, Header("�M��")]
        private ParticleSystem psLight;

        private string parameterAttack = "Ĳ�o����";
        #endregion

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            SwitchWeapon();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �����Z��
        /// </summary>
        private void SwitchWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                goWeaponHand.SetActive(true);
                goWeaponBack.SetActive(false);

                ani.SetTrigger(parameterAttack);    // Ĳ�o�����ʵe
                psLight.Play();                     // ��������S��
            }
        }
        #endregion
    }
}

