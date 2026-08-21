using Velopack;
using Velopack.Sources;

namespace LuaToolsGui.Services;

/// <summary>
/// Silent background auto-update via Velopack + GitHub Releases. Checks on launch,
/// downloads the (delta) update in the background, and stages it to apply on next exit.
/// <para>
/// Resilience is two-layered: (1) <see cref="ProxiedFileDownloader"/> routes each repo's feed + package
/// downloads through GitHub mirrors for blocked/throttled regions (e.g. China); (2) it tries each repo in
/// <see cref="AppConfig.GithubReleasesRepos"/> in order, so if the PRIMARY repo is gone entirely
/// (banned / DMCA'd / account removed. Something the mirrors can't fix) it falls through to a backup repo.
/// </para>
/// </summary>
public class UpdateService
{
    // One UpdateManager per configured repo, in priority order (primary first). All share the proxied
    // downloader so every repo is also mirror-resilient.
    private readonly UpdateManager[] _managers =
        AppConfig.GithubReleasesRepos
            .Select(repo => new UpdateManager(
                new GithubSource(repo, accessToken: null, prerelease: false,
                    downloader: new ProxiedFileDownloader())))
            .ToArray();

    // The manager whose repo actually produced the staged update. Apply against this same one.
    private UpdateManager? _stagedMgr;
    private UpdateInfo? _staged;

    /// <summary>Raised on the thread pool when an update has finished downloading and is ready.</summary>
    public event Action? UpdateReady;

    /// <summary>True once an update is downloaded and waiting to be applied.</summary>
    public bool HasStagedUpdate => _staged is not null;

    /// <summary>Check for, download, and stage an update. Tries each repo in order until one yields a
    /// usable update; the first success wins. No-op for un-installed (dev) builds.</summary>
    public async Task CheckAndStageAsync()
    {
        // Auto-updater disabled
        await Task.CompletedTask;
    }

    public void ApplyAndRestart(string[]? restartArgs = null)
    {
        // Auto-updater disabled
    }

    public void ApplyOnExit()
    {
        // Auto-updater disabled
    }
}
