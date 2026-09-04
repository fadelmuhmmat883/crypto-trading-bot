using CtyBot.Engine.Domain.Models;
using CtyBot.Persistence.Stores;

namespace CtyBot.Persistence.Repositories;

public sealed class BalanceSnapshotRepository
{
    private readonly SqliteWalletStore _store;

    public BalanceSnapshotRepository(SqliteWalletStore store)
    {
        _store = store;
    }

    public async Task PersistAccountBalancesAsync(
        string vaultId,
        IEnumerable<WalletAccount> accounts,
        CancellationToken cancellationToken)
    {
        await _store.SaveAccountsAsync(vaultId, accounts, cancellationToken).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<WalletAccount>> LoadAccountsWithBalancesAsync(
        string vaultId,
        string? networkId,
        CancellationToken cancellationToken) =>
        await _store.GetAccountsAsync(vaultId, networkId, cancellationToken).ConfigureAwait(false);
}
