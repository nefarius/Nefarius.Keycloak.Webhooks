# PaginationOptions

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Specifies zero-based pagination parameters for list operations.

```csharp
public sealed class PaginationOptions
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [PaginationOptions](./nefarius.keycloak.webhooks.client.models.paginationoptions.md)

## Properties

### <a id="properties-first"/>**First**

Gets or sets the zero-based index of the first result.

```csharp
public Nullable<Int32> First { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[Int32](https://learn.microsoft.com/dotnet/api/system.int32)><br>

### <a id="properties-max"/>**Max**

Gets or sets the maximum number of results. Upstream v0.62 limits this value to 100.

```csharp
public Nullable<Int32> Max { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[Int32](https://learn.microsoft.com/dotnet/api/system.int32)><br>

## Constructors

### <a id="constructors-.ctor"/>**PaginationOptions()**

```csharp
public PaginationOptions()
```
