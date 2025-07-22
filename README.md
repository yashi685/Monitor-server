# 🖥️ Multi-Server Monitor Dashboard

A real-time dashboard to monitor multiple servers' CPU, RAM, and Disk usage, built using ASP.NET Core MVC, Chart.js, and jQuery.

![Dashboard Screenshot](./project.png)

## 🚀 Features

- 📡 Real-time monitoring of multiple servers
- 📈 Live charts for CPU, RAM, and Disk usage
- 💾 Visual alerts for low disk space
- 🧠 Clean and responsive UI using flexbox
- 🔄 Auto-refresh every 60 seconds

## 📷 Dashboard Preview

Each server panel displays:
- Server IP address
- CPU and RAM usage (in %)
- Disk usage for each drive (C:\, D:\, etc.)
- Timestamp of last update
- Pie charts for CPU and RAM
- Bar charts for all drives with color indicators

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core MVC (.NET 6+)
- **Frontend**: Chart.js, jQuery, HTML5, CSS
- **Language**: C#
- **System Monitoring**: `System.Diagnostics`, `System.IO`

## 📂 Project Structure

ServerMonitor/
│
├── Controllers/
│   └── ServerController.cs            # Main controller that provides metrics and endpoints
│
├── Models/
│   ├── ServerInfo.cs                  # Model containing CPU, RAM, and disk data
│   └── DriveInfoModel.cs              # Model for individual drive usage (name, used, free)
│
├── Views/
│   └── Server/
│       ├── Index.cshtml               # Main dashboard view with Chart.js integration
│       └── _ServerStatsPartial.cshtml # Optional partial view for AJAX updates
│
├── wwwroot/
│   └── js/
│       └── monitor.js                 # JavaScript for chart rendering and periodic updates
│
├── wwwroot/
│   └── css/
│       └── site.css                   # Optional CSS styling for layout and responsiveness
│
├── project.png                        # Screenshot used in README
├── README.md                          # Project documentation
├── ServerMonitor.csproj               # Project file for .NET build
└── Program.cs / Startup.cs            # App entry point and configuration (depending on .NET version)
