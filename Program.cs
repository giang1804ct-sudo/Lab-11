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

        Console.WriteLine("=== BƯỚC 2: THỬ NGHIỆM OBSERVER SENSORMONITOR (BẢN NHÁP) ===");

        var monitor = new SensorMonitor();
        var dashboard = new DashboardObserver();

        // Thử nghiệm đăng ký
        monitor.Attach(dashboard);
        monitor.Attach(dashboard); // Lỗi: đăng ký 2 lần do chưa kiểm tra trùng

        var legacy = new LegacySmokeDetector(550); // 55.0% -> WARNING
        ISensor sensor = new SmokeSensorAdapter(legacy);

        Console.WriteLine("\nKiểm tra mức khói 55.0% (WARNING):");
        monitor.CheckSensor("Cảm biến phòng máy A1", sensor);
        Console.WriteLine("-> Nhận xét: Dashboard bị in trùng 2 lần do lỗi đăng ký lặp!");
    }
}
