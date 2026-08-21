# Building LuaTools

This document explains how to build the **LuaTools** WPF (.NET 8) desktop application from source.

---

## 🛠️ Prerequisites

Choose **one** of the following options:

### Option A: Visual Studio 2022 (Recommended for GUI)
* Download and install **Visual Studio 2022 Community (Free)**.
* During installation, make sure to select the **".NET desktop development"** workload.

### Option B: .NET 8 SDK (Command Line)
* Download and install the **[.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**.

---

## 🚀 Building the Project

### Method 1: Using Visual Studio 2022

1. Open `LuaToolsGui.sln` in Visual Studio 2022.
2. Select **Release** (or **Debug**) configuration in the top toolbar.
3. Click **Build** -> **Build Solution** (or press `Ctrl + Shift + B`).
4. The compiled executable will be located at:
   ```text
   src/LuaToolsGui/bin/Release/net8.0-windows/LuaToolsGui.exe
   ```

---

### Method 2: Using .NET CLI (PowerShell / Command Prompt)

1. Open a terminal and navigate to the repository folder:
   ```powershell
   cd "D:\Git Projects\Git repos\LuaTools"
   ```

2. Run the build command:
   ```powershell
   dotnet build src/LuaToolsGui/LuaToolsGui.csproj -c Release
   ```

3. Find your built executable at:
   ```text
   D:\Git Projects\Git repos\LuaTools\src\LuaToolsGui\bin\Release\net8.0-windows\LuaToolsGui.exe
   ```
