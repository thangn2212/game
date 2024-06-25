using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; //biến static khi chuyển sang sêcen khác cũng ko bị mấy dữ liệu 
    public int startMoney = 400;


    public static int Lives;
    public int startLives = 20;


    private void Start()
    {
        Lives = startLives;
        Money = startMoney;
    }
    

}
