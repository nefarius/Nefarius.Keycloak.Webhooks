# KeycloakWebhooksApiException

Namespace: Nefarius.Keycloak.Webhooks.Client

Represents a non-success response returned by the Keycloak webhook management API.

```csharp
public sealed class KeycloakWebhooksApiException : System.Net.Http.HttpRequestException, System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [Exception](https://learn.microsoft.com/dotnet/api/system.exception) → [HttpRequestException](https://learn.microsoft.com/dotnet/api/system.net.http.httprequestexception) → [KeycloakWebhooksApiException](./nefarius.keycloak.webhooks.client.keycloakwebhooksapiexception.md)<br>
Implements [ISerializable](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-data"/>**Data**

```csharp
public IDictionary Data { get; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.idictionary)<br>

### <a id="properties-helplink"/>**HelpLink**

```csharp
public string HelpLink { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-hresult"/>**HResult**

```csharp
public int HResult { get; set; }
```

#### Property Value

[Int32](https://learn.microsoft.com/dotnet/api/system.int32)<br>

### <a id="properties-httprequesterror"/>**HttpRequestError**

```csharp
public HttpRequestError HttpRequestError { get; }
```

#### Property Value

[HttpRequestError](https://learn.microsoft.com/dotnet/api/system.net.http.httprequesterror)<br>

### <a id="properties-innerexception"/>**InnerException**

```csharp
public Exception InnerException { get; }
```

#### Property Value

[Exception](https://learn.microsoft.com/dotnet/api/system.exception)<br>

### <a id="properties-message"/>**Message**

```csharp
public string Message { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-reasonphrase"/>**ReasonPhrase**

Gets the HTTP response reason phrase.

```csharp
public string ReasonPhrase { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-responsebody"/>**ResponseBody**

Gets the response body, if one was returned.

```csharp
public string ResponseBody { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-responseheaders"/>**ResponseHeaders**

Gets the response and content headers.

```csharp
public IReadOnlyDictionary<String, IEnumerable<String>> ResponseHeaders { get; }
```

#### Property Value

[IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[String](https://learn.microsoft.com/dotnet/api/system.string)>><br>

### <a id="properties-source"/>**Source**

```csharp
public string Source { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-stacktrace"/>**StackTrace**

```csharp
public string StackTrace { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-statuscode"/>**StatusCode**

```csharp
public Nullable<HttpStatusCode> StatusCode { get; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[HttpStatusCode](https://learn.microsoft.com/dotnet/api/system.net.httpstatuscode)><br>

### <a id="properties-targetsite"/>**TargetSite**

```csharp
public MethodBase TargetSite { get; }
```

#### Property Value

[MethodBase](https://learn.microsoft.com/dotnet/api/system.reflection.methodbase)<br>

## Constructors

### <a id="constructors-.ctor"/>**KeycloakWebhooksApiException(String, HttpStatusCode, String, String, IReadOnlyDictionary&lt;String, IEnumerable&lt;String&gt;&gt;)**

Initializes a new instance of the [KeycloakWebhooksApiException](./nefarius.keycloak.webhooks.client.keycloakwebhooksapiexception.md) class.

```csharp
public KeycloakWebhooksApiException(string message, HttpStatusCode statusCode, string reasonPhrase, string responseBody, IReadOnlyDictionary<String, IEnumerable<String>> responseHeaders)
```

#### Parameters

`message` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The exception message.

`statusCode` [HttpStatusCode](https://learn.microsoft.com/dotnet/api/system.net.httpstatuscode)<br>
The HTTP response status code.

`reasonPhrase` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The HTTP response reason phrase.

`responseBody` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The response body, if one was returned.

`responseHeaders` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[String](https://learn.microsoft.com/dotnet/api/system.string)>><br>
The response and content headers.
