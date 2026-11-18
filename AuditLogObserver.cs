/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;
using System.Collections.Generic;

namespace CampusSafetyHub;

// Observer ghi nhật ký kiểm toán (Audit Log) phục vụ tra cứu
public sealed class AuditLogObserver : IAlertObserver
{
    private readonly List<string> logs = new();

    public void Update(AlertEvent alertEvent)
    {
        string logEntry = $"[{alertEvent.OccurredAt:HH:mm:ss}] NHẬT KÝ LƯU TRỮ: " +
                          $"{alertEvent.SensorName} phát hiện mức {alertEvent.Severity} ({alertEvent.Value:F1}{alertEvent.Unit})";
        logs.Add(logEntry);
        Console.WriteLine(logEntry);
    }

    public IReadOnlyList<string> GetLogs() => logs.AsReadOnly();
}
