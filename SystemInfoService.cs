using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management; // ✅ for memory
using Microsoft.AspNetCore.Http;

namespace SystemMonitor.Services
{
    public class SystemInfoService
    {
        public string GetClientIP(HttpContext context)
        {
            return context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        }

        public double GetCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            return Math.Round(cpuCounter.NextValue(), 2);
        }

        // ✅ Place this method here ↓↓↓
        public (double usedGB, double totalGB) GetMemoryUsage()
        {
            double totalKB = 0;
            double freeKB = 0;

            var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in searcher.Get())
            {
                totalKB = Convert.ToDouble(obj["TotalVisibleMemorySize"]);
                freeKB = Convert.ToDouble(obj["FreePhysicalMemory"]);
            }

            double usedKB = totalKB - freeKB;
            return (
                Math.Round(usedKB / 1024 / 1024, 2),
                Math.Round(totalKB / 1024 / 1024, 2)
            );
        }

        public (double freeGB, double totalGB) GetDiskSpace()
        {
            var systemDrive = DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady && d.Name == Path.GetPathRoot(Environment.SystemDirectory));
            if (systemDrive == null) return (0, 0);

            return (
                Math.Round(systemDrive.AvailableFreeSpace / (1024.0 * 1024 * 1024), 2),
                Math.Round(systemDrive.TotalSize / (1024.0 * 1024 * 1024), 2)
            );
        }
    }
}
