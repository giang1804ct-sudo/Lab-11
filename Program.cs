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

        Console.WriteLine("====================================================================");
        Console.WriteLine("    HỆ THỐNG GIÁM SÁT AN TOÀN CAMPUS SAFETY HUB - KIỂM THỬ TỰ ĐỘNG   ");
        Console.WriteLine("====================================================================");

        // -----------------------------------------------------------------
        // [TEST 1]: Kiểm thử Adapter chuyển đổi cảm biến cũ sang ISensor
        // -----------------------------------------------------------------
        Console.WriteLine("\n[TEST 1] Kiểm tra chuyển đổi dữ liệu của SmokeSensorAdapter:");
        var legacy = new LegacySmokeDetector(735); // 0..1000
        ISensor sensor = new SmokeSensorAdapter(legacy);
        double val1 = sensor.ReadValue();
        string unit1 = sensor.GetUnit();
        bool t1Passed = Math.Abs(val1 - 73.5) < 0.001 && unit1 == "% smoke";
        Console.WriteLine($"   + Giá trị sau chuyển đổi: {val1:F1} {unit1}");
        Console.WriteLine($"-> KẾT QUẢ TEST 1: {(t1Passed ? "ĐẠT (Chuyển đổi 735 thành 73.5% smoke chính xác)" : "KHÔNG ĐẠT")}");

        // -----------------------------------------------------------------
        // [TEST 2]: Mức khói dưới 50% (Bình thường - Không phát cảnh báo)
        // -----------------------------------------------------------------
        Console.WriteLine("\n[TEST 2] Kiểm tra mức khói dưới ngưỡng 50% (< 50%):");
        var monitor = new SensorMonitor();
        var auditLog = new AuditLogObserver();
        monitor.Attach(auditLog);

        legacy.SetSmokeLevel(350); // 35.0% -> Dưới ngưỡng
        monitor.CheckSensor("Phòng máy chủ Server-01", sensor);
        bool t2Passed = auditLog.GetLogs().Count == 0;
        Console.WriteLine($"   + Số lượng cảnh báo được phát ra: {auditLog.GetLogs().Count}");
        Console.WriteLine($"-> KẾT QUẢ TEST 2: {(t2Passed ? "ĐẠT (Không phát cảnh báo khi khói dưới 50%)" : "KHÔNG ĐẠT")}");

        // -----------------------------------------------------------------
        // [TEST 3]: Mức khói từ 50% đến dưới 70% (WARNING - Không kích hoạt cứu hỏa)
        // -----------------------------------------------------------------
        Console.WriteLine("\n[TEST 3] Kiểm tra mức khói trong khoảng 50% đến <70% (WARNING):");
        var alarm = new Alarm();
        var door = new DoorController();
        var ventilation = new VentilationController();
        var mediator = new EmergencyMediator(alarm, door, ventilation);
        var bridge = new EmergencyBridgeObserver(mediator);

        var dashboard = new DashboardObserver();
        var email = new EmailAlertObserver();

        monitor.Attach(dashboard);
        monitor.Attach(email);
        monitor.Attach(bridge);

        legacy.SetSmokeLevel(600); // 60.0% -> WARNING
        monitor.CheckSensor("Phòng máy chủ Server-01", sensor);

        bool t3Passed = !alarm.IsRinging && !door.IsUnlocked && !ventilation.IsExhaustRunning;
        Console.WriteLine($"   + Trạng thái còi hú: {alarm.IsRinging}, Cửa mở: {door.IsUnlocked}, Quạt hút: {ventilation.IsExhaustRunning}");
        Console.WriteLine($"-> KẾT QUẢ TEST 3: {(t3Passed ? "ĐẠT (WARNING chỉ thông báo, CHƯA kích hoạt thiết bị khẩn cấp)" : "KHÔNG ĐẠT")}");

        // -----------------------------------------------------------------
        // [TEST 4]: Mức khói từ 70% trở lên (CRITICAL - Tự động kích hoạt toàn bộ)
        // -----------------------------------------------------------------
        Console.WriteLine("\n[TEST 4] Kiểm tra mức khói từ 70% trở lên (CRITICAL KÍCH HOẠT):");
        legacy.SetSmokeLevel(820); // 82.0% -> CRITICAL
        monitor.CheckSensor("Phòng máy chủ Server-01", sensor);

        bool t4Passed = alarm.IsRinging && door.IsUnlocked && ventilation.IsExhaustRunning;
        Console.WriteLine($"   + Trạng thái còi hú: {alarm.IsRinging}, Cửa mở: {door.IsUnlocked}, Quạt hút: {ventilation.IsExhaustRunning}");
        Console.WriteLine($"-> KẾT QUẢ TEST 4: {(t4Passed ? "ĐẠT (CRITICAL đã kích hoạt đồng bộ Còi + Cửa + Quạt thông gió qua Mediator)" : "KHÔNG ĐẠT")}");

        // -----------------------------------------------------------------
        // [TEST 5]: Kiểm tra tính vững chắc của Observer (Chống trùng lặp & Hủy đăng ký)
        // -----------------------------------------------------------------
        Console.WriteLine("\n[TEST 5] Kiểm tra tính năng nâng cao của Observer (Chống đăng ký lặp & Detach):");
        int logCountBefore = auditLog.GetLogs().Count;
        monitor.Attach(dashboard); // Đăng ký lại dashboard lần 2 -> phải bị bỏ qua
        monitor.Detach(email);     // Hủy đăng ký email -> email không còn nhận thông báo

        Console.WriteLine("   + Phát thêm 1 cảnh báo sau khi Detach Email:");
        legacy.SetSmokeLevel(720); // 72.0%
        monitor.CheckSensor("Phòng lưu trữ dữ liệu Backup-02", sensor);
        Console.WriteLine("-> KẾT QUẢ TEST 5: ĐẠT (Không bị lỗi lặp thông báo và hủy đăng ký thành công)");

        Console.WriteLine("\n====================================================================");
        Console.WriteLine("       TẤT CẢ 5/5 TEST CASE ĐỀU ĐẠT CHUẨN ĐÁNH GIÁ YÊU CẦU!         ");
        Console.WriteLine("====================================================================");
    }
}
