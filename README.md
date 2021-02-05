# Token Based Authentication

**Token Based Authentication** is a process where the client application first sends a request to Authentication server with a valid credentials. The Authentication server sends an Access token to the client as a response. This token contains enough data to identify a particular user and it has an expiry time. Then the client application uses the token to access the restricted resources in the next requests until the token is valid.

If the Access token is expired, then the client application can request for a new access token by using Refresh token.

![TokenBasedAuthentication](https://csharpcorner.azureedge.net/article/web-ap/Images/TokenBasedAuthorization_1.png)

## Advantages of Token Based Authentication

* Scalability of Servers.
* Loosely Coupling.
* Mobile Friendly.

## References Used

* Microsoft.Owin.Host.SystemWeb
* Microsoft.Owin.Security.OAuth
* Microsoft.Owin.Cors
* Dapper
* NUnit
* Moq
* Ninject

