using Unity.Cinemachine;
using UnityEngine;

public class CinemachineRotator : MonoBehaviour
{
    // 7.2 정도로 세팅하면 부드럽게 회전합니다.
    public float rotateSpeed = 7.2f;
    private CinemachineOrbitalFollow follow;

    void Start()
    {
        // 내 몸에 붙은 유니티 6 전용 시네머신 오비탈 팔로우 컴포넌트를 가져옵니다.
        follow = GetComponent<CinemachineOrbitalFollow>();
    }

    void Update()
    {
        if (follow == null) return;

        // ★ [핵심 수정] 곱하기(*)가 아닌 더하기(+=)를 사용해야 매 프레임 지정한 속도만큼 등속 회전합니다!
        follow.HorizontalAxis.Value += rotateSpeed * Time.deltaTime;

        // 팁: 시네머신의 궤도 각도는 360도를 넘어가도 내부적으로 0~360도로 자동 순환(Clamp) 제어되므로 안심하고 더하셔도 됩니다!
    }
}