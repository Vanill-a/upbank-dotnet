# :zap: UpBank .NET
Work with the Up API in .NET using this SDK.
## Links
- [Up API Documentation](https://developer.up.com.au/)
- [Up API Github](https://github.com/up-banking/api)
## :racing_car: Getting Started
Up requires a personal access token to interact with their API.
To acquire a personal access token, follow the steps outlined under _Claim your Personal Access Token_ in their [Getting Started](https://developer.up.com.au/#getting-started) section.
> [!CAUTION]
> A personal access token is **highly sensitive information**.
> Ensure that it is stored securely.
> Do **not** commit it to version control.
### Dependency Injection
Register the `UpClient` for dependency injection using the `AddUpClient` extension method, to which a personal access token must be supplied:
```csharp
using UpBank;

builder.Services.AddUpClient("PERSONAL_ACCESS_TOKEN");
```
## :wrench: Usage
Interact with the UP API using the `UpClient`.
This class provides methods for interacting with the various endpoints.
For example, to retrieve a specific transaction:
```csharp
using UpBank;

var transaction = client.GetTransaction("TRANSACTION_ID");
```
### Queries
For relevant endpoints, the `UpClient` can be used to build queries.
Given their limited number, extension methods have been provided to apply filters available to relevant endpoints.
Once finalized, an `UpQueryReader<T>` can be created to send the request and page through responses.
For example:
```csharp
using UpBank;
using UpBank.Query;

// create a query using the UpClient and apply desired filters
var query = client.CreateAccountQuery()
    .FilterAccountType("SAVER")
    .WithPageSize(10);

// create a reader to send the request and enumerate through response pages
var reader = query.ExecuteReader();

// either manually page through
// or let the reader automatically compile all pages
var nextpage = reader.GetNextPageData();
var remaining = reader.GetAllRemainingPageData();
```
