# Authentication System - Backend Kurulum Kılavuzu

## 🔧 Gerekli NuGet Paketleri

Backend projesine aşağıdaki NuGet paketlerini eklemeniz gerekmektedir:

### CarBook.Persistence Projesi

```bash
# BCrypt için password hashing
dotnet add package BCrypt.Net-Next

# JWT token işlemleri için
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```

### CarBook.Api Projesi

```bash
# JWT Authentication (eğer yoksa)
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

## 📊 Database Migration

RefreshToken tablosunu veritabanına eklemek için migration oluşturun:

### Visual Studio Package Manager Console:

```powershell
# Package Manager Console'u açın (Tools > NuGet Package Manager > Package Manager Console)
# Default project: CarBook.Persistence seçin

Add-Migration AddRefreshTokenTable
Update-Database
```

### .NET CLI:

```bash
# CarBook.Persistence klasörüne gidin
cd CarBook\CarBook.Persistence

# Migration oluştur
dotnet ef migrations add AddRefreshTokenTable --startup-project ..\CarBook.Api\CarBook.Api.csproj

# Veritabanını güncelle
dotnet ef database update --startup-project ..\CarBook.Api\CarBook.Api.csproj
```

## ⚙️ Konfigürasyon

### appsettings.json Güvenlik Notları

**ÖNEMLİ**: Production ortamında JWT SecretKey'i environment variable olarak saklamalısınız:

```json
{
  "JwtSettings": {
    "SecretKey": "ENVIRONMENT_VARIABLE_KULLANIN!",
    "Issuer": "CarBookApi",
    "Audience": "CarBookClient",
    "AccessTokenExpirationMinutes": 15,  // Production'da daha kısa
    "RefreshTokenExpirationDays": 7
  }
}
```

### Environment Variables (Production)

```bash
# Linux/Mac
export JWT_SECRET_KEY="YourSuperSecretProductionKey..."

# Windows CMD
set JWT_SECRET_KEY=YourSuperSecretProductionKey...

# Windows PowerShell
$env:JWT_SECRET_KEY="YourSuperSecretProductionKey..."
```

## 🧪 Test İşlemleri

### 1. İlk Kullanıcıyı Oluşturun

API'yi çalıştırın ve Swagger'a gidin: `https://localhost:5291/swagger`

#### Kullanıcı Kaydı (Register):

```json
POST /api/Auth/Register
{
  "userName": "Test",
  "userLastName": "User",
  "email": "test@example.com",
  "password": "Test123!"
}
```

**Başarılı Yanıt:**
```json
{
  "success": true,
  "message": "Kayıt başarılı",
  "userId": 1
}
```

### 2. Giriş Yapın (Login):

```json
POST /api/Auth/Login
{
  "email": "test@example.com",
  "password": "Test123!"
}
```

**Başarılı Yanıt:**
```json
{
  "success": true,
  "message": "Giriş başarılı",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "kQHx8fN8Hh3RjMvzJ/0sKw==...",
  "expiryDate": "2025-10-05T10:00:00Z",
  "userId": 1,
  "email": "test@example.com",
  "userName": "Test",
  "userLastName": "User"
}
```

### 3. Token ile Korumalı Endpoint'e Erişim:

Swagger'da sağ üstteki **Authorize** butonuna tıklayın ve token'ı yapıştırın:

```
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

Ardından test endpoint'ini çağırın:

```
GET /api/Auth/Me
```

**Başarılı Yanıt:**
```json
{
  "userId": "1",
  "email": "test@example.com",
  "name": "Test User",
  "message": "Authenticated successfully"
}
```

### 4. Token Yenileme (Refresh Token):

```json
POST /api/Auth/RefreshToken
{
  "refreshToken": "kQHx8fN8Hh3RjMvzJ/0sKw==..."
}
```

### 5. Çıkış (Logout):

```json
POST /api/Auth/Logout
{
  "refreshToken": "kQHx8fN8Hh3RjMvzJ/0sKw==..."
}
```

## 🗄️ Veritabanı Yapısı

### RefreshTokens Tablosu:

| Column | Type | Description |
|--------|------|-------------|
| RefreshTokenId | int | Primary Key |
| UserId | int | Foreign Key (Users) |
| Token | nvarchar | Refresh token string |
| ExpiryDate | datetime2 | Token expiry date |
| IsRevoked | bit | Token revocation status |
| CreatedDate | datetime2 | Creation timestamp |
| CreatedByIp | nvarchar | IP address of creator |
| RevokedDate | datetime2 | Revocation timestamp |
| RevokedByIp | nvarchar | IP address of revoker |

### Users Tablosu Güncellendi:

- `RefreshTokens` navigation property eklendi

## 🔒 Güvenlik Özellikleri

✅ **BCrypt Password Hashing** - Güvenli şifre saklama
✅ **JWT Access Token** - Kısa ömürlü erişim token'ı (60 dakika)
✅ **Refresh Token** - Uzun ömürlü yenileme token'ı (7 gün)
✅ **Token Revocation** - Logout sırasında token iptal
✅ **IP Tracking** - Token işlemlerinde IP kaydı
✅ **Token Expiry Check** - Otomatik süre dolum kontrolü

## 📁 Eklenen Dosyalar

### Domain Layer:
- `RefreshToken.cs` - RefreshToken entity

### Application Layer:
- `IPasswordHasher.cs` - Password hashing interface
- `ITokenService.cs` - Token service interface
- `IRefreshTokenRepository.cs` - RefreshToken repository interface
- `LoginCommand.cs` - Login command ve result
- `RefreshTokenCommand.cs` - Refresh command ve result
- `RevokeTokenCommand.cs` - Revoke command ve result
- `RegisterCommand.cs` - Register command ve result
- `LoginCommandHandler.cs` - Login handler
- `RefreshTokenCommandHandler.cs` - Refresh handler
- `RevokeTokenCommandHandler.cs` - Revoke handler
- `RegisterCommandHandler.cs` - Register handler

### Persistence Layer:
- `PasswordHasher.cs` - BCrypt implementation
- `TokenService.cs` - JWT token service
- `RefreshTokenRepository.cs` - Repository implementation
- `ServiceRegistration.cs` - DI configuration

### API Layer:
- `AuthController.cs` - Authentication endpoints
- `Program.cs` - Updated with JWT configuration
- `appsettings.json` - JWT settings

## 🚀 Sonraki Adımlar

1. ✅ NuGet paketlerini yükleyin
2. ✅ Migration çalıştırın
3. ✅ API'yi başlatın ve test edin
4. ➡️ Frontend entegrasyonu yapın

## ⚠️ Önemli Notlar

1. **Production'da mutlaka HTTPS kullanın**
2. **JWT SecretKey'i environment variable'da saklayın**
3. **Rate limiting ekleyin** (brute force saldırılarına karşı)
4. **CORS ayarlarını production için güncelleyin**
5. **Token expiry sürelerini güvenlik politikanıza göre ayarlayın**

---

**Backend authentication sistemi hazır!** 🎉
