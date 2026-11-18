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

        Console.WriteLine("=== BƯỚC 3: KIỂM THỬ OBSERVER HOÀN THIỆN (DASHBOARD, EMAIL, AUDITLOG) ===");

        var monitor = new SensorMonitor();
        var dashboard = new DashboardObserver();
        var email = new EmailAlertObserver();
        var auditLog = new AuditLogObserver();

        // Kiểm tra tính năng chống đăng ký trùng
        monitor.Attach(dashboard);
        monitor.Attach(dashboard); // Bị bỏ qua, không bị lặp
        monitor.Attach(email);
        monitor.Attach(auditLog);

        var legacy = new LegacySmokeDetector(620); // 62.0% -> WARNING
        ISensor sensor = new SmokeSensorAdapter(legacy);

        Console.WriteLine("\n[Kiểm tra phát cảnh báo mức WARNING (62.0%)]:");
        monitor.CheckSensor("Phòng máy chủ Server-Room-01", sensor);

        Console.WriteLine("\n[Kiểm tra hủy đăng ký Email (Detach)]:");
        monitor.Detach(email);

        legacy.SetSmokeLevel(650); // 65.0% -> WARNING
        monitor.CheckSensor("Phòng máy chủ Server-Room-01", sensor);
        Console.WriteLine("-> Nhận xét: Email đã được hủy đăng ký thành công, không còn nhận thông báo.");
    }
}
