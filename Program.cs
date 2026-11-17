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

        Console.WriteLine("=== BƯỚC 1: KIỂM THỬ ADAPTER CHO CẢM BIẾN KHÓI CŨ ===");

        // Khởi tạo cảm biến cũ với giá trị 735 (thang đo 0..1000)
        var legacy = new LegacySmokeDetector(735);
        Console.WriteLine($"Thiết bị cũ: {legacy.GetDescription()}");
        Console.WriteLine($"Mức khói thô từ thiết bị cũ: {legacy.GetSmokeLevel()}");

        // Sử dụng Adapter để chuyển đổi sang interface chuẩn ISensor
        ISensor sensor = new SmokeSensorAdapter(legacy);
        Console.WriteLine("\nĐọc qua SmokeSensorAdapter:");
        Console.WriteLine($"Giá trị chuẩn hóa: {sensor.ReadValue():F1}{sensor.GetUnit()}");

        bool passed = Math.Abs(sensor.ReadValue() - 73.5) < 0.001 && sensor.GetUnit() == "% smoke";
        Console.WriteLine($"-> KẾT QUẢ ADAPTER: {(passed ? "ĐẠT CHUẨN" : "CHƯA ĐẠT")}");
    }
}
