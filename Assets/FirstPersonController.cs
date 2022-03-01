using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneMission
{
    public class FirstPersonController : MonoBehaviour
    {

        // Скорость передвижения игрока
        [SerializeField] private float speed = 10.0f;

        // Компонент CharacterController
        private CharacterController cc;

        void Start()
        {
            // Получаем компонент CharacterController
            cc = GetComponent<CharacterController>();
        }
        
        void FixedUpdate()
        {
            // Получаем нажатия предустановленных клавиш
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float jump = Input.GetAxis("Jump");

            // Записываем данные в отдельную переменную
            Vector3 input = new Vector3(horizontal, vertical, jump);
            // Определяем направление движения
            Vector3 desiredMove = transform.forward * input.y + transform.right * input.x + transform.up * input.z;
            Vector3 moveDir = new Vector3(desiredMove.x * speed, desiredMove.y * speed, desiredMove.z * speed);
            // Передвигаем объект
            cc.Move(moveDir * Time.fixedDeltaTime);
        }
    }
}