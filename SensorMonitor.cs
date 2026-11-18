/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;
using System.Collections.Generic;

namespace CampusSafetyHub;

// Subject quản lý Observer, đọc cảm biến và phát cảnh báo (Đã sửa lỗi an toàn)
public sealed class SensorMonitor
{
    private readonly List<IAlertObserver> observers = new();

    // 1. Không cho cùng một observer đăng ký hai lần
    public void Attach(IAlertObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    // 2. Có thể hủy đăng ký observer
    public void Detach(IAlertObserver observer)
    {
        observers.Remove(observer);
    }

    public void CheckSensor(string sensorName, ISensor sensor)
    {
        double value = sensor.ReadValue();
        string? severity = value switch
        {
            >= 70 => "CRITICAL",
            >= 50 => "WARNING",
            _ => null
        };

        if (severity is null)
        {
            return;
        }

        var alertEvent = new AlertEvent(
            sensorName,
            value,
            sensor.GetUnit(),
            severity,
            DateTime.Now);

        Notify(alertEvent);
    }

    private void Notify(AlertEvent alertEvent)
    {
        // 3. Duyệt trên bản sao ToArray() để observer có thể bị gỡ trong khi thông báo
        // mà không làm hỏng vòng lặp (Collection was modified)
        foreach (IAlertObserver observer in observers.ToArray())
        {
            try
            {
                // 5. Một observer lỗi không được làm sai dữ liệu của observer khác
                observer.Update(alertEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LỖI OBSERVER {observer.GetType().Name}]: {ex.Message}");
            }
        }
    }
}
