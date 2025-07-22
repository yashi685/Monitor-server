using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class ServerInfoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllServers()
    {
        var servers = new List<ServerInfo>();
        string filePath = "C:\\Users\\yashi\\OneDrive\\Desktop\\ServerMetrics.xlsx";

        try
        {
            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

            foreach (var row in rows)
            {
                try
                {
                    var server = new ServerInfo
                    {
                        Id = int.Parse(row.Cell(1).GetString()),
                        ServerIPAddress = row.Cell(2).GetString(),
                        DriveSpace = JsonSerializer.Deserialize<List<DriveInfo>>(row.Cell(3).GetString()),
                        CpuUtilization = double.Parse(row.Cell(4).GetString()),
                        RamUtilization = double.Parse(row.Cell(5).GetString()),
                        PulledTime = row.Cell(6).GetString()
                    };
                    servers.Add(server);
                }
                catch (Exception exRow)
                {
                    Console.WriteLine($"Skipped row: {exRow.Message}");
                }
            }
            return Ok(servers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error reading Excel file: {ex.Message}");
        }
    }

    public class ServerInfo
    {
        public int Id { get; set; }
        public string ServerIPAddress { get; set; }
        public List<DriveInfo> DriveSpace { get; set; }
        public double CpuUtilization { get; set; }
        public double RamUtilization { get; set; }
        public string PulledTime { get; set; }
    }

    public class DriveInfo
    {
        public string drive { get; set; }
        public string freespace { get; set; }
    }
}
