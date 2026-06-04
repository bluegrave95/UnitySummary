using UnityEngine;
using UnityEngine.UI;

public class CounterDisplayer : MonoBehaviour
{
    public Text text;
    public Counter spawunCounter;
    public Counter normalCounter;
    public Counter errorCounter;

    void Update()
    {
        // 변수들이 제대로 연결 안 되었을 때를 대비한 방어 코드
        if (text == null || spawunCounter == null || normalCounter == null || errorCounter == null) return;

        // 1. [핵심] 아직 생산된 제품이 없다면(0개라면) 불량률을 계산하지 않고 0%로 강제 고정합니다.
        float errorRate = 0f;

        if (spawunCounter.count > 0)
        {
            // 정상적으로 1개 이상 생산되었을 때만 나눗셈 연산을 수행합니다.
            errorRate = (float)errorCounter.count / spawunCounter.count;
        }

        // 2. 문자열을 합쳐서 UI 텍스트에 뿌려줍니다.
        // :P1 규격을 사용하면 소수점 첫째 자리까지의 퍼센트 표기(예: 5.3%)를 알아서 만들어 줍니다.
        text.text = $"생성수 : {spawunCounter.count}개, 불량률 : ({errorRate:P1})\n" +
                    $"정상 : {normalCounter.count}개\n" +
                    $"불량 : {errorCounter.count}개";
    }
}