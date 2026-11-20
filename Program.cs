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

        Console.WriteLine("=== BƯỚC 5: TÍCH HỢP EMERGENCYBRIDGE KHỞI ĐỘNG KHI CRITICAL ===");

        // 1. Khởi tạo các thiết bị ứng phó và Mediator
        var alarm = new Alarm();
        var door = new DoorController();
        var ventilation = new VentilationController();
        var mediator = new EmergencyMediator(alarm, door, ventilation);

        // 2. Khởi tạo SensorMonitor và các Observer
        var monitor = new SensorMonitor();
        monitor.Attach(new DashboardObserver());
        monitor.Attach(new EmailAlertObserver());
        monitor.Attach(new EmergencyBridgeObserver(mediator));

        // 3. Khởi tạo cảm biến cũ qua Adapter
        var legacy = new LegacySmokeDetector(550); // 55.0% -> WARNING (Chưa kích hoạt mediator)
        ISensor sensor = new SmokeSensorAdapter(legacy);

        Console.WriteLine("\n--- THỬ NGHIỆM 1: Mức khói 55.0% (WARNING) ---");
        monitor.CheckSensor("Phòng máy chủ DC-01", sensor);
        Console.WriteLine($"-> Trạng thái còi hú: {alarm.IsRinging} (Đúng mong đợi: WARNING chưa hú còi)");

        Console.WriteLine("\n--- THỬ NGHIỆM 2: Mức khói 75.0% (CRITICAL) ---");
        legacy.SetSmokeLevel(750); // 75.0% -> CRITICAL -> Kích hoạt toàn bộ thiết bị
        monitor.CheckSensor("Phòng máy chủ DC-01", sensor);
        Console.WriteLine($"-> Trạng thái còi hú: {alarm.IsRinging} (Đúng mong đợi: CRITICAL đã kích hoạt ứng phó)");
    }
}
