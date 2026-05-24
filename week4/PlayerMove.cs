using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Animation Names")]
    public string upAnime = "";    // 위쪽 방향 애니메이션 이름
    public string downAnime = "";  // 아래쪽 방향 애니메이션 이름
    public string rightAnime = ""; // 오른쪽 방향 애니메이션 이름
    public string leftAnime = "";  // 왼쪽 방향 애니메이션 이름

    [Header("Movement Settings")]
    public float speed = 3.0f;     // 이동 속도 (원하는 대로 조절 가능)

    private string nowMode = "";
    private Vector3 movement;

    void Start()
    {
        // 시작할 때 아래를 바라보는 애니메이션을 기본값으로 설정
        nowMode = downAnime;
    }

    void Update()
    {
        movement = Vector3.zero;

        // 키보드 방향키 또는 WASD 입력 감지 및 애니메이션 변경
        if (Input.GetKey("up") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            nowMode = upAnime;
            movement += Vector3.up;
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            nowMode = downAnime;
            movement += Vector3.down;
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            nowMode = rightAnime;
            movement += Vector3.right;
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            nowMode = leftAnime;
            movement += Vector3.left;
        }
    }

    void FixedUpdate()
    {
        // 애니메이션 재생
        if (this.GetComponent<Animator>() != null && !string.IsNullOrEmpty(nowMode))
        {
            this.GetComponent<Animator>().Play(nowMode);
        }

        // 캐릭터 실제 이동 처리
        transform.position += movement.normalized * speed * Time.fixedDeltaTime;
    }
}
