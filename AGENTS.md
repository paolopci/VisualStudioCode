# Repository Guidelines

## Project Structure & Module Organization
The solution is a single ASP.NET Core WebAPI project rooted here. Key folders:
- `Controllers/` hosts HTTP entry points such as `ProductController`.
- `Models/` contains DTOs and domain models; e.g., `Product`.
- `Repositories/` encapsulates data access abstractions and implementations (currently `InMemoryProductRepository`).
- `Properties/`, `appsettings*.json`, and `Program.cs` provide hosting and configuration defaults.
Keep new services or features aligned with this layout; prefer adding dedicated folders for cross-cutting concerns (e.g., `Services/`, `Infrastructure/`) rather than mixing responsibilities.

## Build, Test, and Development Commands
- `dotnet build` — Compiles the solution and restores packages.
- `dotnet run` — Launches the API locally on the configured port.
- `dotnet watch run` — Hot-reloads on code changes; ideal during feature development.
- `dotnet test` — Executes the unit-test suite (add tests under `Tests/` when introduced).

## Coding Style & Naming Conventions
Follow standard C# conventions: PascalCase for classes, interfaces (prefix interfaces with `I`, e.g., `IProductRepository`), and methods; camelCase for locals and parameters. Use 4-space indentation and keep files scoped to a single public type. Inject dependencies via constructor injection and register them in `Program.cs`. When adding comments, favor short, purposeful explanations over restating obvious logic.

## Testing Guidelines
Adopt xUnit (default with `dotnet new xunit`) for unit coverage. Place tests in a parallel `Tests/` project mirroring the namespace layout (e.g., `Controllers/ProductControllerTests`). Name test methods using `MethodName_Scenario_ExpectedOutcome`. Run `dotnet test` before submitting changes, and add minimal builders or fakes rather than mocking framework internals.

## Commit & Pull Request Guidelines
Write commits in the imperative mood (`Add product search endpoint`) and keep them scoped to a single change set. Reference work items or issues in the commit body when applicable. Pull requests should summarize the change, call out breaking impacts, reference related tickets, and include manual-test notes or `dotnet test` output. Attach screenshots or sample payloads for API changes so reviewers can validate quickly.

## Security & Configuration Tips
Never commit secrets in `appsettings.json`; prefer environment variables or user secrets. Validate incoming models with `[Required]` and related attributes before persisting new data sources. When introducing persistence, contain configuration in dedicated options classes and register them via `builder.Services.Configure<TOptions>()`.
