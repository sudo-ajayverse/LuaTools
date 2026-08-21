using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace LuaToolsGui.Services;

/// <summary>
/// Anonymous app-launch analytics via a self-hosted Umami instance. Posts a single "app_launch" event
/// per launch to Umami's /api/send (the same endpoint the browser script calls). No personal data.
/// Just an event name + app version. Best-effort fire-and-forget: never throws, never blocks startup.
/// </summary>
public class AnalyticsService
{
    private readonly HttpClient _http = new() { Timeout = TimeSpan.FromSeconds(10) };

    private static readonly string Version =
        Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion is { } v && v.IndexOf('+') is var i and >= 0 ? v[..i]
        : Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "?";

    /// <summary>Report one app launch. Silent no-op on any failure.</summary>
    public async Task TrackAppLaunchAsync(CancellationToken ct = default)
    {
        // Telemetry disabled
        await Task.CompletedTask;
    }
}
