.Net Core 3.1 Web API Design (Blog API)
======================================= 

Kullanýlan Teknolojiler ve Yapýsý
---------------------------------

- .Net Core 3.1 Web Api 
- versioning
- Jwt bearer authentication
- swagger documentation
- serilog logger
- EF Core 
- Repository pattern 
- Db Migration
- Mssql
- xUnit Tests
- dependency injection 
- docker
- project layers 

Kurulum (Installation)
----------------------
Projeyi çalýþtýrabilmek için ;
<br/>
.NET Core 3.1 SDK 
<br/>
[Windows](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-windows-x64-installer)
|
[Linux](https://docs.microsoft.com/dotnet/core/install/linux-package-managers)
|
[MacOS](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-macos-x64-installer)
<br/>
[Docker Kurulum için](https://docs.docker.com/get-docker/) ve [Docker SDK](https://hub.docker.com/_/microsoft-dotnet-core)
<br/>
[.NET Core SDK Detay için](https://dotnet.microsoft.com/download)

DB Scriptleri(Migration)
------------------------
Ben mssql localdb kullandým;

Ýsteðe baðlý ```DbContextFactory.cs ```  da düzeltme yapýlabilir ```var connectionString =""; ``` alanýna veritabanýn connectionString yazýn


projenin  ```.....\Blog\src\Libraries\Blog.Data ``` yolunda command line açýn (eðer entity'lerde deðiþiklik yapmadýysanýz ```dotnet ef database update``` komutu çalýþtýrmanýz yeterli olacaktýr.)

```sh
#restore Blog.Data project
...Blog.Data_> dotnet restore #eðer entity'lerde deðiþiklik yaptýysanýz

#build Blog.Data project
...Blog.Data_> dotnet build #eðer entity'lerde deðiþiklik yaptýysanýz

#add Initial name migrations 
...Blog.Data_> dotnet ef migrations add [Initial | {chege'in ismi yazýn}] #eðer entity'lerde deðiþiklik yaptýysanýz

#Update migrations on database
...Blog.Data_> dotnet ef database update
#dotnet ef database update Initial

```

```appsettings.json``` da ```"DefaultConnection": "..."``` alanýna veritabanýn connectionString yazýn
``` 
 "ConnectionStrings": {
    "DefaultConnection": "..."
  },
```


Soru - Açýklama:
----------------

- <b> Projede kullanýlan tasarým desenleri ve neden kullanýldý? </b> 
  - Domain Driven Design (DDD): Proje bittiðinde sürekliliðini saðlamak ve problemleri çözmek için; Yazýlýmcýlarýn Domain uzmanlarý ile ayný dili konuþmasý kavramlar tüm ekip için ayný þey ifade etmeli. Komplex bir domain de sub domainlere ayýrmak. Entity, kendine ait bir kimliðe sahip olmasý. Value object, temel tipler, mapleme, list, diziler vs. Aggregate Root, birbiri ile iliþkili entityler ya da bir iþ kuralý bir arada kullanýlmasý. Repository, bir aggregate içindeki Entity ve value objectlerin taþýdýðý bilgilerin veri tabanýna iþlemesi kavramýdýr ve AR kendi içinde transactinal yapýda gerçekleþtirir. Katmanlý mimari, Domain, Application, Presentaion ve infrastructure katmanlarý. Refactoring, yeni özeliklerle birlikte ileþtirmek. Temiz ve okunabilir kod.
  - Test Driven Development (TDD): Tasarla-> Test yaz-> Testin sonucu baþarýsýz-> kodla-> Test sonucu baþarýlý; bir koda parçasýnýn bir tek case için gerçekleþtirilir. Baþta maliyeti büyük olur proje sonlarýna doðru çok verimli olmaya baþlar ve yeni istekler geldikçe daha hýzlý geliþtirme yapýlýr buglar yakalanýr. “Refactoring” ön plana çýkar.
  - Dependency inversion(D)- Abstractions (Information Hiding)- Inversion of Control (IoC)- Dependency Injection(DI): (D)Baðýmlýlýklarýn tersine çevirmek, somut kavram baðýmlýklarý soyut kavram baðýmlýlýklarý yönüne çevirmek. (A)Baðýmlýlýklara detaylara deðil genellemelere baðlý olmalý bunu interface’lerle yapmak mümkün bu sayede detaylardan soyutlanmýþ oluyor. (IoC) Kotta ki baðýmlýklarýmýzý azaltmak için objelerin yaratýlacaðý zaman kontrolün bir framework geçmesi. (DI) Baðýmlýlýklarý dýþardan enjekte ederek çalýþmasýna devam eder.
  - Repository Pattern: Veri tabanýnda bir tablo için yapýlan CRUD(Create-Read-Update-Delete) iþlemleri; Generic bir yapýda her tablo için ayný iþlemleri gerçekleþtirebilen tasarýmdýr. Kod tekrarý ortada kaldýrýlmýþ olur ve ayný zaman da veri tabanýna eriþim tek yerde yönetimini saðlamýþ olur.

- <b> Daha önce ki tecrübelerimden kullandýðým teknoloji ve kütüphaneler ...</b> 
  - Daha önce böyle bir wep api yazdým yapý olara aynýydý;
  - .Net Core 2.2 Web Api 
  - api versiyonlama yapýldý(versioning)
  - Jwt kütüphanesi kullanýldý(Jwt bearer authentication), 
  - swagger kütüphanesi api dökümantasyon için kullanýldý(swagger documentation)
  - serilog kütüphanesi loglama için kullnýldý(serilog logger)
  - Entity Framework Core kullanýldý (EF Core)
  - Repository pattern kullanýldý
  - Microsoft.VisualStudio.Web.CodeGeneration.Tools db scriptleri için kullanýldý(Db Migration)
  - Birim testler için xUnit kullanýdý(xUnit Tests)
  - .net core ' nin yapýsýnda gelen "Microsoft.Extensions.DependencyInjection.Abstractions" dependency injection için kullanýldý (dependency injection)
  - Katmanlý mimari uygulandý(project layers)

- <b> Daha geniþ vaktim olsaydý projeye neler eklerdim? </b>
   - Audit yapýsý kurardým.
   - Bir web projeside "vue js" veye "react" front-end frameworklerden birini kullanarak api entegrasyonunu yapardým.

- <b> Ek olarak ... </b> 
    - Docker konfigrasyonu yapýldý ve docker'dan deployment edilebilir. PC'nide Docker kuruluysa proje solutionýna klasöründe command line ```docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build``` komutu yazmanýz yeterlidir. Docker'da testteleri çalýþtýrmak için de ```docker-compose -f docker-compose-tests.yml -f docker-compose-tests.override.yml up --build``` komutu çalýþtýrmanýz yeterli olacaktýr.