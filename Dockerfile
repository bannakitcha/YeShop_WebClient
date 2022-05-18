#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Y_eShopWeb_Client/Y_eShopWeb_Client.csproj", "Y_eShopWeb_Client/"]
COPY ["Y_eShop_Common/Y_eShop_Common.csproj", "Y_eShop_Common/"]
COPY ["Y_eShop_Models/Y_eShop_Models.csproj", "Y_eShop_Models/"]
COPY ["Y_eShop_DataAccess/Y_eShop_DataAccess.csproj", "Y_eShop_DataAccess/"]
RUN dotnet restore "Y_eShopWeb_Client/Y_eShopWeb_Client.csproj"
COPY . .
WORKDIR "/src/Y_eShopWeb_Client"
RUN dotnet build "Y_eShopWeb_Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Y_eShopWeb_Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Y_eShopWeb_Client.dll"]
