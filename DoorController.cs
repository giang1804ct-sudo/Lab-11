/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Thiết bị điều khiển hệ thống cửa phòng và cửa thoát hiểm
public sealed class DoorController
{
    private bool isUnlocked;

    public void UnlockAllDoors()
    {
        isUnlocked = true;
        Console.WriteLine("[HỆ THỐNG CỬA]: ĐÃ MỞ KHÓA TOÀN BỘ CỬA THOÁT HIỂM TỰ ĐỘNG!");
    }

    public void LockAllDoors()
    {
        isUnlocked = false;
        Console.WriteLine("[HỆ THỐNG CỬA]: ĐÃ KHÓA CÁC CỬA AN TOÀN.");
    }

    public bool IsUnlocked => isUnlocked;
}
