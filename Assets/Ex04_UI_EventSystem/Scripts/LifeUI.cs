using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Slider lifeslider;           // 슬라이더
    public Text lifeText;               // 텍스트
    public Vector3 offset;              // 위치고정

    public Transform target;            // 따라다닐 게임오브젝트
    public Transform camTransform;      // 바라봐야할 카메라 위치정보

    private void Start()
    {
        GameObject go = GameObject.Find("WorldCanvas");

        transform.SetParent(go.transform);

        GameObject can = GameObject.Find("WorldCanvas");

        transform.SetParent(go.transform);
    }

    private void LateUpdate()           //lateUpdate 나중에 한번 더해주는 명령어
    {
        // 씬 안에 WorldCanvas라고 되어 있는 게임오브젝트를 찾는 함수.
        GameObject go = GameObject.Find("WorldCanvas");
        //게임오브젝트의 부모를 설정하는 함수.
        if (camTransform == null) return;

        //타겟의 위치로 변경하고 카메라의 정면 방향으로 회전시킴.
        transform.SetPositionAndRotation(target.position + offset, camTransform.rotation);
    }


}
