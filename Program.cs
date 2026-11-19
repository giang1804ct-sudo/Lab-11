/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;
using System.Text;

namespace CampusSafetyHub;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== BƯỚC 4: THỬ NGHIỆM ĐIỀU PHỐI ĐỘC LẬP QUA MEDIATOR ===");

        var alarm = new Alarm();
        var door = new DoorController();
        var ventilation = new VentilationController();

        var mediator = new EmergencyMediator(alarm, door, ventilation);

        Console.WriteLine("\n[Thử nghiệm phát sự kiện FIRE_DETECTED thủ công]:");
        mediator.TriggerEmergency("FIRE_DETECTED");

        bool allActivated = alarm.IsRinging && door.IsUnlocked && ventilation.IsExhaustRunning;
        Console.WriteLine($"-> KẾT QUẢ ĐIỀU PHỐI: {(allActivated ? "TẤT CẢ THIẾT BỊ ĐÃ KÍCH HOẠT ĐỒNG THỜI" : "CHƯA HOÀN TẤT")}");
    }
}
