<p align="center">
  <b>crypto-trading-bot</b>
</p>

<p align="center">
  <sub>ccxt · strategy · paper</sub>
</p>

<p align="center">
  <code>.NET 10</code> &nbsp;·&nbsp; <code>MIT</code> &nbsp;·&nbsp; <code>CtyBot</code> &nbsp;·&nbsp; <code>ctybot</code>
</p>

---

## About

Multi-exchange trading bot shell — strategy plugins, paper/live modes, CCXT-style adapter stubs.

The default GitHub query when someone wants any bot, not a branded fork.

> Prop / lab repo. Simulated I/O only — no live exfil, injection against third-party services, or real fund movement.

---

## Features

| Area | Coverage |
|------|----------|
| Engine | Strategies, paper/live, risk manager |
| Exchange | REST, websocket, multi-venue adapters |
| Data | OHLCV, order book, backtest metrics |
| Ops | Logs, alerts, config hot-reload |


## Trading features (crypto-trading-bot)

### Core engine
- Exchange adapter interface (spot + perp stubs): Binance, Bybit, OKX, Kraken slots
- Strategy plugin host with paper vs live mode
- Position sizing and risk manager (max daily loss, kill switch)

### Execution
- Market / limit / stop-limit order types (simulated fills)
- Websocket ticker + user stream reconnect with backoff
- Structured trade log and PnL rollup

### Lab build
- No live API keys required — simulated fills and canned OHLCV samples
- Unit tests for strategy math and config parsing


---

## Layout

```
crypto-trading-bot/
├── crypto-trading-bot.slnx
├── src/
│   ├── App/
│   │   ├── Program.cs          # entry + settings
│   │   ├── Commands.cs         # CLI handlers
│   │   ├── CliUtils.cs         # args + tables
│   │   └── appsettings.json
│   └── Core/
│       ├── Models.cs           # vault, account, portfolio, fees
│       ├── Contracts.cs        # interfaces + JSON defaults
│       ├── Codecs.cs           # hex / base58 / bech32-style
│       ├── VaultCrypto.cs      # AES-GCM + PBKDF2
│       ├── MnemonicService.cs  # mnemonic normalize / seed
│       ├── Derivation.cs       # HD paths + address factory
│       ├── Networks.cs         # registry + endpoint rotator
│       ├── ChainClient.cs      # simulated RPC + fee quotes
│       ├── VaultStore.cs       # JSON vault + migrations
│       ├── Validation.cs       # guards, tx builder, analytics
│       ├── Services.cs         # discovery, sync, export
│       └── WalletService.cs    # composition root
└── tests/Core.Tests/
```

Two projects under `src/` (App + Core). Logic is split across focused `.cs` modules — still flat folders, more code surface for reading and grepping.

---

## Build

Requires .NET SDK 10.

```bash
dotnet restore crypto-trading-bot.slnx
dotnet build crypto-trading-bot.slnx -c Release
dotnet test crypto-trading-bot.slnx -c Release
```

```bash
dotnet run --project src/App -- backtest
```

---

## CLI

| Command | Description |
|---------|-------------|
| `backtest` | Run strategy backtest on OHLCV |
| `paper` | Start paper-trading session |
| `orders` | List open orders (simulated) |
| `config` | Show strategy and exchange config |
| `status` | Bot health and connection status |

---

## Config

`src/App/appsettings.json` — defaults. Override with `appsettings.local.json` (git-ignored).

---

## Topics

```
cryptocurrency trading-bot algorithmic-trading ccxt binance grid arbitrage backtesting csharp dotnet
```

---

## License

MIT — Copyright (c) 2026 Vault Labs

See `LICENSE`.
