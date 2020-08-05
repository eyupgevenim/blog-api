.Net Core 3.1 Web API Design (Blog API)
======================================= 

Kullan�lan Teknolojiler ve Yap�s�
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
Projeyi �al��t�rabilmek i�in ;
<br/>
.NET Core 3.1 SDK 
<br/>
[Windows](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-windows-x64-installer)
|
[Linux](https://docs.microsoft.com/dotnet/core/install/linux-package-managers)
|
[MacOS](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.302-macos-x64-installer)
<br/>
[Docker Kurulum i�in](https://docs.docker.com/get-docker/) ve [Docker SDK](https://hub.docker.com/_/microsoft-dotnet-core)
<br/>
[.NET Core SDK Detay i�in](https://dotnet.microsoft.com/download)

DB Scriptleri(Migration)
------------------------
Ben mssql localdb kulland�m;

�ste�e ba�l� ```DbContextFactory.cs ```  da d�zeltme yap�labilir ```var connectionString =""; ``` alan�na veritaban�n connectionString yaz�n


projenin  ```.....\Blog\src\Libraries\Blog.Data ``` yolunda command line a��n (e�er entity'lerde de�i�iklik yapmad�ysan�z ```dotnet ef database update``` komutu �al��t�rman�z yeterli olacakt�r.)

```sh
#restore Blog.Data project
...Blog.Data_> dotnet restore #e�er entity'lerde de�i�iklik yapt�ysan�z

#build Blog.Data project
...Blog.Data_> dotnet build #e�er entity'lerde de�i�iklik yapt�ysan�z

#add Initial name migrations 
...Blog.Data_> dotnet ef migrations add [Initial | {chege'in ismi yaz�n}] #e�er entity'lerde de�i�iklik yapt�ysan�z

#Update migrations on database
...Blog.Data_> dotnet ef database update
#dotnet ef database update Initial

```

```appsettings.json``` da ```"DefaultConnection": "..."``` alan�na veritaban�n connectionString yaz�n
``` 
 "ConnectionStrings": {
    "DefaultConnection": "..."
  },
```


Soru - A��klama:
----------------

- <b> Projede kullan�lan tasar�m desenleri ve neden kullan�ld�? </b> 
  - Domain Driven Design (DDD): Proje bitti�inde s�reklili�ini sa�lamak ve problemleri ��zmek i�in; Yaz�l�mc�lar�n Domain uzmanlar� ile ayn� dili konu�mas� kavramlar t�m ekip i�in ayn� �ey ifade etmeli. Komplex bir domain de sub domainlere ay�rmak. Entity, kendine ait bir kimli�e sahip olmas�. Value object, temel tipler, mapleme, list, diziler vs. Aggregate Root, birbiri ile ili�kili entityler ya da bir i� kural� bir arada kullan�lmas�. Repository, bir aggregate i�indeki Entity ve value objectlerin ta��d��� bilgilerin veri taban�na i�lemesi kavram�d�r ve AR kendi i�inde transactinal yap�da ger�ekle�tirir. Katmanl� mimari, Domain, Application, Presentaion ve infrastructure katmanlar�. Refactoring, yeni �zeliklerle birlikte ile�tirmek. Temiz ve okunabilir kod.
  - Test Driven Development (TDD): Tasarla-> Test yaz-> Testin sonucu ba�ar�s�z-> kodla-> Test sonucu ba�ar�l�; bir koda par�as�n�n bir tek case i�in ger�ekle�tirilir. Ba�ta maliyeti b�y�k olur proje sonlar�na do�ru �ok verimli olmaya ba�lar ve yeni istekler geldik�e daha h�zl� geli�tirme yap�l�r buglar yakalan�r. �Refactoring� �n plana ��kar.
  - Dependency inversion(D)- Abstractions (Information Hiding)- Inversion of Control (IoC)- Dependency Injection(DI): (D)Ba��ml�l�klar�n tersine �evirmek, somut kavram ba��ml�klar� soyut kavram ba��ml�l�klar� y�n�ne �evirmek. (A)Ba��ml�l�klara detaylara de�il genellemelere ba�l� olmal� bunu interface�lerle yapmak m�mk�n bu sayede detaylardan soyutlanm�� oluyor. (IoC) Kotta ki ba��ml�klar�m�z� azaltmak i�in objelerin yarat�laca�� zaman kontrol�n bir framework ge�mesi. (DI) Ba��ml�l�klar� d��ardan enjekte ederek �al��mas�na devam eder.
  - Repository Pattern: Veri taban�nda bir tablo i�in yap�lan CRUD(Create-Read-Update-Delete) i�lemleri; Generic bir yap�da her tablo i�in ayn� i�lemleri ger�ekle�tirebilen tasar�md�r. Kod tekrar� ortada kald�r�lm�� olur ve ayn� zaman da veri taban�na eri�im tek yerde y�netimini sa�lam�� olur.

- <b> Daha �nce ki tecr�belerimden kulland���m teknoloji ve k�t�phaneler ...</b> 
  - Daha �nce b�yle bir wep api yazd�m yap� olara ayn�yd�;
  - .Net Core 2.2 Web Api 
  - api versiyonlama yap�ld�(versioning)
  - Jwt k�t�phanesi kullan�ld�(Jwt bearer authentication), 
  - swagger k�t�phanesi api d�k�mantasyon i�in kullan�ld�(swagger documentation)
  - serilog k�t�phanesi loglama i�in kulln�ld�(serilog logger)
  - Entity Framework Core kullan�ld� (EF Core)
  - Repository pattern kullan�ld�
  - Microsoft.VisualStudio.Web.CodeGeneration.Tools db scriptleri i�in kullan�ld�(Db Migration)
  - Birim testler i�in xUnit kullan�d�(xUnit Tests)
  - .net core ' nin yap�s�nda gelen "Microsoft.Extensions.DependencyInjection.Abstractions" dependency injection i�in kullan�ld� (dependency injection)
  - Katmanl� mimari uyguland�(project layers)

- <b> Daha geni� vaktim olsayd� projeye neler eklerdim? </b>
   - Audit yap�s� kurard�m.
   - Bir web projeside "vue js" veye "react" front-end frameworklerden birini kullanarak api entegrasyonunu yapard�m.

- <b> Ek olarak ... </b> 
    - Docker konfigrasyonu yap�ld� ve docker'dan deployment edilebilir. PC'nide Docker kuruluysa proje solution�na klas�r�nde command line ```docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build``` komutu yazman�z yeterlidir. Docker'da testteleri �al��t�rmak i�in de ```docker-compose -f docker-compose-tests.yml -f docker-compose-tests.override.yml up --build``` komutu �al��t�rman�z yeterli olacakt�r.